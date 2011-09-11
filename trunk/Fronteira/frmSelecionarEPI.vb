Imports Persistencia
Public Class frmSelecionarEPI

#Region " Enumerações "

    Private Enum eColunasGrid
        Marcar = 0
        Quantidade = 1
        IDEPI = 2
        Descricao = 3
        CA = 4
        ExpiraEm = 5
        Fornecedor = 6
    End Enum

#End Region

#Region "Variáveis"

    Private dtbEPI As New DataTable
    Private dtbDados As New DataTable
    Private sPrvListaEPI As String
    Private iPrvIDEPI As Integer
    Private iPrvIDFuncionario As Integer
    Private sNomeFuncionario As String
    Private btPrvFiltro As Byte
    Private bResultado As Boolean
    Private dtPrvDataEntrega As Date

    Private objFuncionario As New Controle.ctrFuncionario
    Private objEPI As New Controle.ctrEPI

#End Region

#Region " Propriedades"

    Public ReadOnly Property EPISelecionadas() As DataTable
        Get
            Return Me.dtbDados
        End Get
    End Property

    Public WriteOnly Property DataEntrega()
        Set(ByVal value)
            dtPrvDataEntrega = value
        End Set
    End Property
    Public WriteOnly Property IDFuncionario()
        Set(ByVal value)
            iPrvIDFuncionario = value
        End Set
    End Property
    Public WriteOnly Property NomeFuncionario()
        Set(ByVal value)
            sNomeFuncionario = value
        End Set
    End Property

    Public Property ListaEPI() As String
        Get
            Return Me.sPrvListaEPI
        End Get
        Set(ByVal value As String)
            Me.sPrvListaEPI = value
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

    Private Function Verificar_Qte_Zero() As Boolean
        Dim bRetorno As Boolean = True

        Try

            For cont As Integer = 0 To dgvEPI.RowCount - 1
                If (CBool(dgvEPI.Item(eColunasGrid.Marcar, cont).Value) = True) Then
                    bRetorno = (CInt(dgvEPI.Item(eColunasGrid.Quantidade, cont).Value) > 0)
                End If
            Next

        Catch ex As Exception
            bRetorno = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        Return bRetorno

    End Function

    Private Sub configuraGrid()

        Dim estilo As New DataGridView
        Try
            With Me.dgvEPI

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
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
                Col2.HeaderText = "Qte"
                Col2.Width = 30
                Col2.ReadOnly = False
                Col2.FillWeight = 30
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Código"
                Col3.DataPropertyName = "IDEPI"
                Col3.Width = 50
                Col3.Frozen = False
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = False
                Col3.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "EPI"
                Col4.DataPropertyName = "Descricao"
                Col4.Width = 260
                Col4.Frozen = False
                Col4.ReadOnly = True
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewTextBoxColumn()
                Col5.HeaderText = "CA"
                Col5.DataPropertyName = "CA"
                Col5.Width = 50
                Col5.Frozen = False
                Col5.ReadOnly = True
                Col5.FillWeight = 35
                Col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col5.SortMode = DataGridViewColumnSortMode.Automatic
                Col5.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Col5.Visible = True
                Col5.ValueType = System.Type.GetType("System.String")

                .Columns.Add(Col5)

                Dim Col6 As New DataGridViewTextBoxColumn()
                Col6.HeaderText = "Expira Em"
                Col6.DataPropertyName = "ExpiraEm"
                Col6.Width = 60
                Col6.Frozen = False
                Col6.ReadOnly = True
                Col6.FillWeight = 61
                Col6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col6.SortMode = DataGridViewColumnSortMode.Automatic
                Col6.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Col6.Visible = True
                Col6.ValueType = System.Type.GetType("System.Date")

                .Columns.Add(Col6)

                Dim Col7 As New DataGridViewTextBoxColumn()
                Col7.HeaderText = "Fornecedor"
                Col7.DataPropertyName = "Fornecedor"
                Col7.Width = 50
                Col7.Frozen = False
                Col7.ReadOnly = True
                Col7.FillWeight = 100
                Col7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col7.SortMode = DataGridViewColumnSortMode.Automatic
                Col7.Visible = True
                Col7.ValueType = System.Type.GetType("System.Date")

                .Columns.Add(Col7)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Function Gravar() As Boolean
        Dim sEpi As String = ""
        Dim bRetorno As Boolean = False
        Dim sMsg As String = ""

        Try
            If (Not Verificar_Qte_Zero()) Then
                sMsg = "Atenção!" & Environment.NewLine
                sMsg &= "Existem equipamentos marcados com quantidade igual a 0 (zero). "
                sMsg &= "Estes não serão registrados." & Environment.NewLine & Environment.NewLine
                sMsg &= "Deseja continuar?"

                If (MsgBox(sMsg, MsgBoxStyle.YesNo, "SegTrab - Atenção") = MsgBoxResult.No) Then
                    Exit Function
                End If
            End If

            If (dgvEPI.Rows.Count > 0) Then
                Me.objEPI.Incluir_EPI_Funcionario(Me.iPrvIDFuncionario, dgvEPI, dtEntrega.Text)
            End If

            bRetorno = True

        Catch ex As Exception
            bRetorno = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        Return bRetorno

    End Function

    Private Function Verificar_EPI_Incluido(ByVal iIDEPI As Integer) As Boolean
        Dim bRetorno As Boolean = False

        Try
            For cont As Integer = 0 To dgvEPI.RowCount - 1
                If (dgvEPI.Item(eColunasGrid.IDEPI, cont).Value = iIDEPI) Then
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
        Dim sData As String
        Dim iLinha As Integer = 0

        Try
            Me.dgvEPI.Rows.Clear()
            Me.dtbEPI = Me.objEPI.Selecionar_EPI_Funcionario(Me.iPrvIDFuncionario, dtPrvDataEntrega, btPrvFiltro)

            If Me.dtbEPI.Rows.Count > 0 Then

                With Me.dgvEPI
                    .RowCount = Me.dtbEPI.Rows.Count

                    For Each drDados As DataRow In Me.dtbEPI.Rows

                        .Item(eColunasGrid.Marcar, iLinha).Value = InStr(Me.sPrvListaEPI, Conversao.ToString(drDados.Item("IDEpi"))) > 0
                        .Item(eColunasGrid.IDEPI, iLinha).Value = Conversao.ToString(drDados.Item("IDEPI"))
                        .Item(eColunasGrid.Descricao, iLinha).Value = Conversao.ToString(drDados.Item("Descricao"))
                        .Item(eColunasGrid.CA, iLinha).Value = Conversao.ToString(drDados.Item("CA"))
                        sData = Conversao.ToDateTime(drDados.Item("ExpiraEm")).ToString("dd/MM/yyyy")
                        .Item(eColunasGrid.ExpiraEm, iLinha).Value = IIf(sData = Date.MinValue, DBNull.Value, sData)

                        If (.Item(eColunasGrid.ExpiraEm, iLinha).Value Is DBNull.Value) Then
                            .Rows(iLinha).DefaultCellStyle.ForeColor = Color.Red
                        ElseIf (CDate(.Item(eColunasGrid.ExpiraEm, iLinha).Value) < CDate(dtPrvDataEntrega)) Then
                            .Rows(iLinha).DefaultCellStyle.ForeColor = Color.Red
                        ElseIf (DateDiff(DateInterval.Month, CDate(.Item(eColunasGrid.ExpiraEm, iLinha).Value), CDate(dtPrvDataEntrega)) = 1) Then
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

    Private Sub selecaoGrid(ByVal bMarcar As Boolean)

        For iContador As Integer = 0 To Me.dgvEPI.Rows.Count - 1
            Me.dgvEPI.Item(eColunasGrid.Marcar, iContador).Value = bMarcar
        Next

    End Sub

    Private Sub frmSelecionarEPI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "EPI - " & Me.sNomeFuncionario
        Me.configuraGrid()
        Me.preencheGrid()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click

        If (Me.Gravar()) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
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

    Private Sub cmdSelecionarEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarFuncionario.Click
        Dim frmDialogo As New frmPesquisa

        Try

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
                        Me.iPrvIDEPI = .ID
                        txtEPI.Text = objEPI.Retornar_Descricao_EPI(Me.iPrvIDEPI)
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
            If (Not Verificar_EPI_Incluido(Me.iPrvIDEPI)) Then
                With Me.dgvEPI

                    .RowCount = .RowCount + 1
                    .Item(eColunasGrid.Marcar, .RowCount - 1).Value = True
                    .Item(eColunasGrid.IDEPI, .RowCount - 1).Value = iPrvIDEPI
                    .Item(eColunasGrid.Descricao, .RowCount - 1).Value = txtEPI.Text.Trim

                    txtEPI.Clear()
                    iPrvIDEPI = 0
                    cmdIncluir.Enabled = False
                End With
            Else
                MsgBox("EPI já incluída.", MsgBoxStyle.Exclamation, Me.Text)
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

#End Region

    Private Sub dgvEPI_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEPI.CellValueChanged
        Select e.ColumnIndex
            Case eColunasGrid.Quantidade
                dgvEPI.Item(eColunasGrid.Marcar, e.RowIndex).Value = True
        End Select
    End Sub

End Class