Imports Controle
Imports Persistencia

Public Class frmEpiFuncionario

#Region "Enumerações"
    Private Enum eColunasGrid
        Codigo = 0
        Descricao = 1
        CA = 2
        Entrega = 3
        Qte = 4
        Devolucao = 5
        Inativo = 6
    End Enum
#End Region

#Region "Variáveis"
    Private iPrvIDFuncionario As Integer
    Private iPrvIDEpi As Integer
    Private WithEvents objRelEpi As New Relatorio.relEPI
    Private dtPrvEntrega As Date

    Private objEpi As New ctrEPI
    Private objFuncionario As New ctrFuncionario
#End Region

    Private Sub Configurar_Grid()

        Try

            With Me.dgvEquipamentos
                .DataSource = Nothing
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "Código"
                Col1.DataPropertyName = "IDEpi"
                Col1.Width = 40
                Col1.Frozen = False
                Col1.ReadOnly = True
                'Col1.FillWeight = 40
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col1.SortMode = DataGridViewColumnSortMode.Automatic
                Col1.Visible = False
                Col1.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "EPI"
                Col2.DataPropertyName = "Descricao"
                Col2.Frozen = False
                Col2.ReadOnly = True
                Col2.Width = 290
                Col2.FillWeight = 290
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "CA"
                Col3.DataPropertyName = "CA"
                Col3.Frozen = False
                Col3.ReadOnly = True
                Col3.FillWeight = 50
                Col3.Width = 50
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Entrega"
                Col4.DataPropertyName = "DataEntrega"
                Col4.Frozen = False
                Col4.ReadOnly = True
                Col4.FillWeight = 80
                Col4.Width = 80
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.Date")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewTextBoxColumn()
                Col5.HeaderText = "Qte"
                Col5.DataPropertyName = "Quantidade"
                Col5.FillWeight = 35
                Col5.Width = 35
                Col5.Frozen = False
                Col5.ReadOnly = True
                Col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col5.SortMode = DataGridViewColumnSortMode.Automatic
                Col5.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Col5.Visible = True
                Col5.ValueType = System.Type.GetType("System.Int")
                .Columns.Add(Col5)

                Dim Col6 As New DataGridViewTextBoxColumn()
                Col6.HeaderText = "Devolvido"
                Col6.DataPropertyName = "Devolucao"
                Col6.Frozen = False
                Col6.ReadOnly = True
                Col6.FillWeight = 80
                Col6.Width = 80
                Col6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col6.SortMode = DataGridViewColumnSortMode.Automatic
                Col6.Visible = True
                Col6.ValueType = System.Type.GetType("System.Date")
                .Columns.Add(Col6)

                Dim Col7 As New DataGridViewCheckBoxColumn
                Col7.HeaderText = "Inativo"
                Col7.Frozen = False
                Col7.FillWeight = 45
                Col7.Width = 45
                Col7.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col7.SortMode = DataGridViewColumnSortMode.NotSortable
                Col7.ReadOnly = True
                Col7.Visible = True
                Col7.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col7)

                .Refresh()

            End With
            cmdAdicionarEPI.Enabled = False
            cmdExcluirEPI.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub Preencher_EPI()
        Dim dtbEpi As New DataTable
        Dim linhasSelecionadas As DataGridViewSelectedRowCollection
        Dim iLinha As Integer = 0
        Dim sData As String

        Try
            dtbEpi = objEpi.Selecionar_EPI_Entregue(iPrvIDFuncionario, Date.MinValue)

            If dtbEpi.Rows.Count > 0 Then

                With dgvEquipamentos
                    .RowCount = dtbEpi.Rows.Count

                    For Each drDados As DataRow In dtbEpi.Rows

                        .Item(eColunasGrid.Codigo, iLinha).Value = Conversao.ToString(drDados.Item("IDEPI"))
                        .Item(eColunasGrid.Qte, iLinha).Value = Conversao.ToString(drDados.Item("Quantidade"))
                        .Item(eColunasGrid.Descricao, iLinha).Value = Conversao.ToString(drDados.Item("Descricao"))
                        .Item(eColunasGrid.CA, iLinha).Value = Conversao.ToString(drDados.Item("CA"))
                        sData = Conversao.ToDateTime(drDados.Item("DataEntrega")).ToString("dd/MM/yyyy")
                        .Item(eColunasGrid.Entrega, iLinha).Value = IIf(sData = Date.MinValue, DBNull.Value, sData)
                        sData = Conversao.ToDateTime(drDados.Item("Devolucao")).ToString("dd/MM/yyyy")
                        .Item(eColunasGrid.Devolucao, iLinha).Value = IIf(sData = Date.MinValue, DBNull.Value, sData)
                        .Item(eColunasGrid.Inativo, iLinha).Value = CBool(Conversao.nuloParaBoleano(drDados.Item("Inativo")))

                        iLinha += 1
                    Next

                End With

            End If

            dtbEpi = Nothing
            cmdExcluirEPI.Enabled = (dgvEquipamentos.RowCount > 0)
            cmdDevolver.Enabled = (dgvEquipamentos.RowCount > 0)

            dgvEquipamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            linhasSelecionadas = dgvEquipamentos.SelectedRows
            If (linhasSelecionadas.Count = 1) Then
                iPrvIDEpi = linhasSelecionadas.Item(0).Cells(eColunasGrid.Codigo).Value
                dtPrvEntrega = linhasSelecionadas.Item(0).Cells(eColunasGrid.Entrega).Value
            End If
            dgvEquipamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdSelecionarFuncionario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarFuncionario.Click
        Dim frmDialogo As New frmPesquisa

        Try

            With frmDialogo
                .Sql = objFuncionario.sqlConsulta(0, Persistencia.Globais.iIDEmpresa)
                .Titulo = "Pesquisa Funcionário"
                .CarregaTela()
                If (.DS.Tables(0).Rows.Count > 0) Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        Me.iPrvIDFuncionario = Persistencia.Conversao.ToString(.ID)
                        Me.txtFuncionario.Text = Me.objFuncionario.Retornar_Nome_Funcionario(Me.iPrvIDFuncionario)
                        Me.Preencher_EPI()
                        Me.cmdAdicionarEPI.Enabled = True
                        Me.cmdImpressao.Enabled = True
                    End If
                Else
                    MsgBox("Registro não encontrado.", MsgBoxStyle.Exclamation, Me.Text)
                    cmdAdicionarEPI.Enabled = False
                    Exit Sub
                End If
            End With

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try
    End Sub

    Private Sub cmdAdicionarEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarEPI.Click
        Dim acesso As New Persistencia.AcessoBd

        Dim frm As New frmSelecionarEPI
        frm.DataEntrega = acesso.Data_Servidor
        frm.IDFuncionario = Me.iPrvIDFuncionario
        frm.NomeFuncionario = txtFuncionario.Text
        frm.ShowDialog()

        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.Preencher_EPI()
        End If
    End Sub

    Private Sub frmEpiFuncionario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Configurar_Grid()
        Me.cmdImpressao.Enabled = False
    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

    Private Sub cmdExcluirEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirEPI.Click
        Dim sMsg As String

        Try
            If (iPrvIDEpi > 0) Then
                sMsg = "Tem certeza que deseja inativar este equipamento? " & vbCrLf
                sMsg &= "Esta operação não poderá ser desfeita."

                If (MsgBox(sMsg, MsgBoxStyle.YesNo, "Atenção") = MsgBoxResult.Yes) Then
                    objEpi.Inativar_EPI_Funcionario(iPrvIDEpi, iPrvIDFuncionario, dtPrvEntrega)
                    Preencher_EPI()
                End If
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub dgvEquipamentos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipamentos.CellClick

        Try
            If (e.RowIndex >= 0) Then
                iPrvIDEpi = dgvEquipamentos.Item(eColunasGrid.Codigo, e.RowIndex).Value
                dtPrvEntrega = dgvEquipamentos.Item(eColunasGrid.Entrega, e.RowIndex).Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub dgvEquipamentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipamentos.CellContentClick

        Try
            If (e.RowIndex > 0) Then
                iPrvIDEpi = dgvEquipamentos.Item(eColunasGrid.Codigo, e.RowIndex).Value
                dtPrvEntrega = dgvEquipamentos.Item(eColunasGrid.Entrega, e.RowIndex).Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdDevolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevolver.Click
        Dim sMsg As String
        Dim dtDevolucao As Date

        Try
            If (iPrvIDEpi > 0) Then
                sMsg = "Tem certeza que deseja devolver este equipamento? " & vbCrLf

                If (MsgBox(sMsg, MsgBoxStyle.YesNo, "Atenção") = MsgBoxResult.Yes) Then
                    frmDevolucaoEPI.ShowDialog()
                    If (frmDevolucaoEPI.DialogResult = Windows.Forms.DialogResult.OK) Then
                        dtDevolucao = frmDevolucaoEPI.Datadevolucao
                        objEpi.Devolver_EPI(iPrvIDFuncionario, iPrvIDEpi, dtPrvEntrega, dtDevolucao)
                        Preencher_EPI()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdImpressao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpressao.Click
        Dim frmRelEPI As New frmRelEPI
        With frmRelEPI
            .IDEmpresa = Globais.iIDEmpresa
            .IDFuncionario = Me.iPrvIDFuncionario
            .Show()
        End With
    End Sub
End Class