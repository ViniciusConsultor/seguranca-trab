Imports Controle
Imports Persistencia
Public Class frmAssocNR

#Region "Enumerações"

    Private Enum eColunasGrid
        CodNR = 0
        Descricao = 1
        Aplicavel = 2
        Validade = 3

    End Enum

#End Region

#Region "Variáveis"
    Private bPrvSomenteLeitura As Boolean

    Private objEmpresa As New ctrEmpresa
    Private objNR As New ctrNR
#End Region

    Private Sub Configurar_Grid()

        Try

            With Me.dgvNR
                .DataSource = Nothing
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col_CodNR As New DataGridViewTextBoxColumn()
                With Col_CodNR
                    .HeaderText = "NR"
                    .Width = 30
                    .Frozen = True
                    .ReadOnly = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Int32")
                End With
                .Columns.Add(Col_CodNR)

                Dim Col_Descricao As New DataGridViewTextBoxColumn()
                With Col_Descricao
                    .HeaderText = "Descrição"
                    .Frozen = True
                    .ReadOnly = True
                    .Width = 350
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                End With
                .Columns.Add(Col_Descricao)

                Dim Col_Aplicavel As New DataGridViewCheckBoxColumn
                With Col_Aplicavel
                    .HeaderText = "Aplicável"
                    .Frozen = False
                    .ReadOnly = False
                    .FillWeight = 60
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .Visible = True
                    .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ValueType = System.Type.GetType("System.boolean")
                End With
                .Columns.Add(Col_Aplicavel)

                Dim Col_ValidadeCheck As New DataGridViewTextBoxColumn
                With Col_ValidadeCheck
                    .HeaderText = "Validade (Meses)"
                    .Frozen = False
                    .ReadOnly = True
                    .FillWeight = 60
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .Visible = True
                    .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ValueType = System.Type.GetType("System.integer")
                End With
                .Columns.Add(Col_ValidadeCheck)

                .Refresh()

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Preencher_NRs()
        Dim dtbNR_Empresa As New DataTable
        Dim iLinha As Integer = 0
        Dim bAplicavel As Boolean = False
        Try

            dtbNR_Empresa = objNR.Retornar_NR_Empresa(Persistencia.Globais.iIDEmpresa)

            If (dtbNR_Empresa.Rows.Count > 0) Then
                With Me.dgvNR
                    .RowCount = dtbNR_Empresa.Rows.Count
                    For Each drDados As DataRow In dtbNR_Empresa.Rows
                        .Item(eColunasGrid.CodNR, iLinha).Value = Conversao.nuloParaZero(drDados.Item("IDNR"))
                        .Item(eColunasGrid.Descricao, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Descricao"))
                        bAplicavel = Conversao.nuloParaBoleano(drDados.Item("Aplicavel"))
                        .Item(eColunasGrid.Aplicavel, iLinha).Value = bAplicavel
                        .Item(eColunasGrid.Aplicavel, iLinha).ReadOnly = bPrvSomenteLeitura
                        .Item(eColunasGrid.Validade, iLinha).ReadOnly = bPrvSomenteLeitura And Not bAplicavel
                        .Item(eColunasGrid.Validade, iLinha).Value = Conversao.nuloParaZero(drDados.Item("Validade"))

                        iLinha += 1
                    Next
                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Public Sub Carregar_Tela(ByVal bSomenteLeitura As Boolean)

        bPrvSomenteLeitura = bSomenteLeitura
        cmdGravar.Enabled = Not bSomenteLeitura

        Call Configurar_Grid()
        Call Preencher_NRs()

        Me.Text &= " - " & objEmpresa.Retornar_Campo_Empresa(Persistencia.Globais.iIDEmpresa, _
                                                                "NomeFantasia")
        Me.ShowDialog()

    End Sub

    Public Sub Salvar()
        Dim dsAssociacao As New DataSet
        Dim sMensagem As String

        Try
            dsAssociacao = Persistencia.Conversao.converteGridParaDataset(dgvNR)
            If (objNR.Salvar_NR_Empresa(Persistencia.Globais.iIDEmpresa, dsAssociacao)) Then
                Me.Close()
            Else

                sMensagem = objNR.MensagemErroAssociacao
                MessageBox.Show(sMensagem, "Atenção", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdSair_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Call Salvar()
    End Sub

    Private Sub dgvNR_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNR.CellClick
        With dgvNR
            If (e.RowIndex >= 0) Then
                If (e.ColumnIndex = eColunasGrid.Aplicavel) Then
                    .Item(eColunasGrid.Validade, e.RowIndex).ReadOnly = .Item(eColunasGrid.Aplicavel, e.RowIndex).Value
                End If
            End If
        End With
    End Sub

End Class