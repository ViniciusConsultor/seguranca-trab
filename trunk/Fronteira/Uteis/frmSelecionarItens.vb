Imports Persistencia
Public Class frmSelecionarItens

#Region "Variáveis"
    Private sPrvSqlItens As String
    Private sPrvMarcados As String
    Private bMarcaTodos As Boolean = True
    Private dsPrvDados As New DataSet

    Private sPrvTitulo As String

    Private objPesquisa As New perPesquisa
    Private objTreinamento As New Controle.ctrTreinamento
#End Region

#Region "Propriedades"

    Public Property Marcados()
        Get
            Return sPrvMarcados
        End Get
        Set(ByVal value)
            sPrvMarcados = value
        End Set
    End Property

    Public WriteOnly Property SqlPesquisa()
        Set(ByVal value)
            sPrvSqlItens = value
        End Set
    End Property

    Public WriteOnly Property Titulo()
        Set(ByVal value)
            sPrvTitulo = value
        End Set
    End Property

#End Region

#Region "Métodos"
    Private Sub Retornar_Marcados()
        Dim cont As Integer

        Try
            sPrvMarcados = String.Empty
            For cont = 0 To dgvItens.RowCount - 1
                If (dgvItens.Item(0, cont).Value) Then
                    If (sPrvMarcados <> "") Then
                        sPrvMarcados &= ","
                    End If
                    sPrvMarcados &= dgvItens.Item(1, cont).Value
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub Setar_Marcados()
        Dim cont As Integer

        If (sPrvMarcados <> String.Empty) Then
            For cont = 0 To dgvItens.RowCount - 1
                dgvItens.Item(0, cont).Value = IIf(InStr(sPrvMarcados, dgvItens.Item(1, cont).Value) > 0, True, False)
                dgvItens.Refresh()
            Next
        End If
    End Sub
    Public Sub Carregar_Tela()
        Try
            dsPrvDados.Clear()
            dsPrvDados = objPesquisa.Pesquisa(sPrvSqlItens)
            If (Not dsPrvDados Is Nothing AndAlso dsPrvDados.Tables(0).Rows.Count > 0) Then
                Me.Configurar_Grid()
                Me.Text = Me.sPrvTitulo
                Me.ShowDialog()
            Else
                MsgBox("Registro não encontrado.", MsgBoxStyle.Exclamation, Application.ProductName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub Configurar_Grid()

        Try
            Dim Colunas As New DataGridViewTextBoxColumn()
            Dim iLinha As Integer = 0
            Dim dsTemp As New DataSet

            With dgvItens
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False

                .Columns.Clear()

                'Coluna para checkbox
                Dim ColCheck As New DataGridViewCheckBoxColumn
                With ColCheck
                    .Width = 20
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Boolean")
                    .Frozen = False
                    .ReadOnly = False
                    .FillWeight = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .RowHeadersVisible = False
                .Columns.Add(ColCheck)

                For Each dcColumns As DataColumn In Me.dsPrvDados.Tables(0).Columns

                    'define cada coluna do grid
                    Dim Col As New DataGridViewTextBoxColumn()
                    With Col
                        .Visible = True
                        'Se a coluna for do tipo Integer (Normalmente será a chave primária da tabela)
                        If Persistencia.Conversao.ToString(dcColumns.DataType) = Persistencia.Conversao.ToString(System.Type.GetType(sTipoCampo(eTipoCampo.TipoInteiro))) Then
                            .Width = 50
                            .ValueType = System.Type.GetType(sTipoCampo(eTipoCampo.TipoString))
                            .Visible = False
                        ElseIf Persistencia.Conversao.ToString(dcColumns.DataType) = Persistencia.Conversao.ToString(System.Type.GetType(sTipoCampo(eTipoCampo.TipoData))) Then
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            .ValueType = System.Type.GetType(sTipoCampo(eTipoCampo.TipoData))
                        Else
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            .ValueType = System.Type.GetType(sTipoCampo(eTipoCampo.TipoString))
                        End If

                        .DataPropertyName = Persistencia.Conversao.ToString(dcColumns.ColumnName)
                        .HeaderText = Persistencia.Conversao.ToString(dcColumns.ColumnName)
                        .Frozen = False
                        .ReadOnly = True
                        .FillWeight = 100

                    End With

                    .Columns.Add(Col)
                    .Refresh()

                Next
                .Rows.Clear()
                .DataSource = Me.dsPrvDados.Tables(0)
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

#End Region

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMarcarTodos.Click
        Dim cont As Integer
        Try
            With dgvItens
                For cont = 0 To .RowCount - 1
                    .Item(0, cont).Value = bMarcaTodos
                Next
            End With

            If (bMarcaTodos) Then
                cmdMarcarTodos.Text = "Desmarca Todos"
            Else
                cmdMarcarTodos.Text = "Marca Todos"
            End If
            bMarcaTodos = Not bMarcaTodos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        Me.Retornar_Marcados()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmSelecionarItens_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Setar_Marcados()
    End Sub
End Class