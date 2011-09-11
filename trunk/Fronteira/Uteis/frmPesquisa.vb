Public Class frmPesquisa

#Region "Enumerações"

    Private Enum eTipoCampo As Byte
        TipoInteiro = 0
        TipoString = 1
        TipoData = 2
    End Enum

#End Region

#Region "Variáveis"

    Private objPesquisa As New Controle.ctrPesquisa
    Private objSeguranca As New Controle.ctrSeguranca
    Private sCampos As String
    Private sDescricoes As String
    Private sLarguras As String
    Private sSql As String
    Private tipoCampo As Type

    Private sTipoCampo As String() = {"System.Int32", _
                                      "System.String", _
                                      "System.DateTime"}

    Private dsDados As New DataSet
    Private iId As Integer
    Private sTitulo As String
    Private sCampoSelecao As String
    Private bDadosCriptografados As Boolean = False
#End Region

#Region "Propriedades"

    Public Property DadosCriptografados() As Boolean
        Get
            Return Me.bDadosCriptografados
        End Get
        Set(ByVal value As Boolean)
            Me.bDadosCriptografados = value
        End Set
    End Property

    Public Property DS() As DataSet
        Get
            Return Me.dsDados
        End Get
        Set(ByVal value As DataSet)
            Me.dsDados = value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return Me.iId
        End Get
        Set(ByVal value As Integer)
            Me.iId = value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return Me.sTitulo
        End Get
        Set(ByVal value As String)
            Me.sTitulo = value
        End Set
    End Property

    Public Property CampoSelecao() As Integer
        Get
            Return Me.sCampoSelecao
        End Get
        Set(ByVal value As Integer)
            Me.sCampoSelecao = value
        End Set
    End Property

    Public WriteOnly Property Campos()
        Set(ByVal value)
            sCampos = value
        End Set
    End Property

    Public WriteOnly Property Descricoes()
        Set(ByVal value)
            sDescricoes = value
        End Set
    End Property

    Public WriteOnly Property Larguras()
        Set(ByVal value)
            sLarguras = value
        End Set
    End Property

    Public WriteOnly Property Sql()
        Set(ByVal value)
            sSql = value
        End Set
    End Property


#End Region

#Region "Funções"

    Private Sub configuraGrid()

        Dim Colunas As New DataGridViewTextBoxColumn()
        Dim iLinha As Integer = 0
        Dim dsTemp As New DataSet

        With dgvGridResultados
            .AutoGenerateColumns = False
            .Columns.Clear()

            For Each dcColumns As DataColumn In Me.DS.Tables(0).Columns

                If Persistencia.Conversao.ToString(dcColumns.DataType) <> Persistencia.Conversao.ToString(System.Type.GetType(Me.sTipoCampo(eTipoCampo.TipoData))) Then
                    Me.cboCampos.Items.Add(Persistencia.Conversao.ToString(dcColumns.ColumnName))
                End If

                'define cada coluna do grid
                Dim Col As New DataGridViewTextBoxColumn()
                With Col

                    'Se a coluna for do tipo Integer (Normalmente será a chave primária da tabela)
                    If Persistencia.Conversao.ToString(dcColumns.DataType) = Persistencia.Conversao.ToString(System.Type.GetType(Me.sTipoCampo(eTipoCampo.TipoInteiro))) Then
                        .Width = 50
                        .ValueType = System.Type.GetType(Me.sTipoCampo(eTipoCampo.TipoString))
                    ElseIf Persistencia.Conversao.ToString(dcColumns.DataType) = Persistencia.Conversao.ToString(System.Type.GetType(Me.sTipoCampo(eTipoCampo.TipoData))) Then
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .ValueType = System.Type.GetType(Me.sTipoCampo(eTipoCampo.TipoData))
                    Else
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .ValueType = System.Type.GetType(Me.sTipoCampo(eTipoCampo.TipoString))
                    End If

                    .DataPropertyName = Persistencia.Conversao.ToString(dcColumns.ColumnName)
                    .HeaderText = Persistencia.Conversao.ToString(dcColumns.ColumnName)
                    .Frozen = False
                    .ReadOnly = True
                    .FillWeight = 100

                    .Visible = True
                End With

                .Columns.Add(Col)
                .Refresh()

            Next

            If Me.bDadosCriptografados Then

                dsTemp = Me.DS.Clone

                For Each drDados As DataRow In Me.DS.Tables(0).Rows
                    dsTemp.Tables(0).Rows.Add(New Object() {drDados.Item("IDUsuario"), _
                                                            Me.objSeguranca.descriptografar(drDados.Item("Nome"))})
                Next

                Me.DS.Clear()

                Me.DS = dsTemp.Copy

            End If

            .DataSource = Me.DS.Tables(0)

        End With

        Me.cboCampos.SelectedIndex = 0
        Me.tipoCampo = Me.dgvGridResultados.Columns(Me.cboCampos.SelectedIndex).ValueType

    End Sub

    Public Sub CarregaTela()
        Try
            Me.DS.Clear()
            Me.DS = Me.objPesquisa.Pesquisa(Me.sSql)

            If Not Me.DS Is Nothing AndAlso Me.DS.Tables(0).Rows.Count > 0 Then

                Me.configuraGrid()

            Else
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub


#End Region

    Private Sub dtGridResultados_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGridResultados.CellClick

        dgvGridResultados.CurrentRow.Selected = True

    End Sub

    Private Sub dtGridResultados_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGridResultados.CellDoubleClick
        If (e.RowIndex >= 0) Then
            Me.ID = Persistencia.Conversao.ToInt32(dgvGridResultados.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub frmPesquisa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            With dgvGridResultados
                If (.SelectedRows.Count = 1) Then
                    For cont As Integer = 0 To .Rows.Count - 1
                        If (.Rows(cont).Selected) Then
                            Me.ID = Persistencia.Conversao.ToInt32(dgvGridResultados.Rows(cont).Cells(0).Value.ToString())
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Exit For
                            Me.Close()
                        End If
                    Next
                End If
            End With
        End If

    End Sub

    Private Sub frmPesquisa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Me.Titulo
        Me.txtCampo.Select()
    End Sub

    Private Sub cboCampos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCampos.SelectedIndexChanged

        Me.txtCampo.Text = String.Empty

        Me.tipoCampo = Me.dgvGridResultados.Columns(Me.cboCampos.SelectedIndex).ValueType

        If Me.tipoCampo.ToString = Me.sTipoCampo(eTipoCampo.TipoInteiro) Then
            Me.txtCampo.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        Else
            Me.txtCampo.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        End If

        Me.txtCampo.Focus()

    End Sub

    Private Sub txtCampo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCampo.TextChanged

        Dim view As New DataView(DS.Tables(0))

        Try

            If Me.txtCampo.Text <> String.Empty Then

                If Me.tipoCampo.ToString = Me.sTipoCampo(eTipoCampo.TipoString) Then
                    view.RowFilter = Me.dgvGridResultados.Columns(Me.cboCampos.SelectedIndex).HeaderText & " like '" & Me.txtCampo.Text & "%'"
                    Me.dgvGridResultados.DataSource = view

                ElseIf Me.tipoCampo.ToString = Me.sTipoCampo(eTipoCampo.TipoInteiro) Then
                    view.RowFilter = Me.dgvGridResultados.Columns(Me.cboCampos.SelectedIndex).HeaderText & "=" & Val(Me.txtCampo.Text)
                    Me.dgvGridResultados.DataSource = view
                End If

            Else
                view.RowFilter = ""
                Me.dgvGridResultados.DataSource = view
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

End Class