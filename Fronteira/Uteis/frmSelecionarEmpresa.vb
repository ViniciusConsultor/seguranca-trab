Imports Persistencia
Public Class frmSelecionarEmpresa

#Region " Variáveis"

    Private objUsuarioEmpresa As New Controle.ctrUsuarioEmpresa
    Private objEmpresa As New Controle.ctrEmpresa
    Private dsEmpresasSelecionadas As New DataSet

    Private iIdUsuario As Integer
    Private iIdEmpresa As Integer
    Private bResultado As Boolean
#End Region

#Region "Propriedades"

    Public Property IDUsuario() As Integer
        Get
            Return Me.iIdUsuario
        End Get
        Set(ByVal value As Integer)
            Me.iIdUsuario = value
        End Set
    End Property

    Public Property IDEmpresa() As Integer
        Get
            Return Me.iIdEmpresa
        End Get
        Set(ByVal value As Integer)
            Me.iIdEmpresa = value
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

#Region " Enumerações "

    Public Enum eColEmpresas
        eIdEmpresa = 0
        eSigla = 1
        eEmpresa = 2
    End Enum

#End Region

    Private Sub formataDtGrid()

        Try
            With Me.dgvEmpresa

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False

                .Columns.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "Código"
                Col1.Width = 60
                Col1.Frozen = True
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Sigla"
                Col2.Width = 70
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.String")
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

    Private Sub PreencherDtGrid(ByVal dsDados As DataSet)

        Dim iLinha As Integer

        Try

            Me.formataDtGrid()

            If dsDados.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvEmpresa

                    .Rows.Clear()
                    .RowCount = dsDados.Tables(0).Rows.Count

                    For Each drDados As DataRow In dsDados.Tables(0).Rows
                        .Item(eColEmpresas.eSigla, iLinha).Value = Conversao.ToString(drDados.Item("Sigla"))
                        .Item(eColEmpresas.eIdEmpresa, iLinha).Value = Conversao.ToString(drDados.Item("IDEmpresa"))
                        .Item(eColEmpresas.eEmpresa, iLinha).Value = Conversao.ToString(drDados.Item("NomeFantasia"))

                        iLinha += 1
                    Next

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmSelecionarEmpresa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dsUsuarioEmpresa As New DataSet
        Dim dsEmpresa As New DataSet

        dsEmpresa = Me.objEmpresa.selecionarDadosEmpresa(0)
        dsUsuarioEmpresa = Me.objUsuarioEmpresa.selecionarUsuarioEmpresa(Me.IDUsuario, _
                                                                         False)

        'Se estiver em modo DEBUG (IDUsuario = 0) seleciona todas as empresas
        'senão seleciona apenas as empresas que o usuário tem acesso
        If Me.IDUsuario > 0 Then
            Me.dsEmpresasSelecionadas = dsUsuarioEmpresa.Copy
        Else
            Me.dsEmpresasSelecionadas = dsEmpresa.Copy
        End If

        Me.PreencherDtGrid(Me.dsEmpresasSelecionadas)

        Me.IDEmpresa = Conversao.ToInt32(Me.dgvEmpresa.Rows(0).Cells(eColEmpresas.eIdEmpresa).Value.ToString())

    End Sub

    Private Sub dgvEmpresa_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpresa.CellClick
        If (e.RowIndex >= 0) Then
            Me.dgvEmpresa.CurrentRow.Selected = True
            Me.IDEmpresa = Conversao.ToInt32(Me.dgvEmpresa.Rows(e.RowIndex).Cells(eColEmpresas.eIdEmpresa).Value.ToString())
        End If
    End Sub

    Private Sub dgvEmpresa_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpresa.CellDoubleClick
        Me.IDEmpresa = Conversao.ToInt32(Me.dgvEmpresa.Rows(e.RowIndex).Cells(eColEmpresas.eIdEmpresa).Value.ToString())
        Me.bResultado = True
        Me.Close()
    End Sub

    Private Sub dgvEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEmpresa.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            With dgvEmpresa
                If (.SelectedRows.Count = 1) Then
                    For cont As Integer = 0 To .Rows.Count - 1
                        If (.Rows(cont).Selected) Then
                            Me.IDEmpresa = Conversao.ToInt32(dgvEmpresa.Rows(cont).Cells(eColEmpresas.eIdEmpresa).Value.ToString())
                            Me.bResultado = True
                            Me.Close()
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.bResultado = False
        Me.Close()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click

        With dgvEmpresa
            If (.SelectedRows.Count = 1) Then
                For cont As Integer = 0 To .Rows.Count - 1
                    If (.Rows(cont).Selected) Then
                        Me.IDEmpresa = Conversao.ToInt32(dgvEmpresa.Rows(cont).Cells(eColEmpresas.eIdEmpresa).Value.ToString())
                        Me.bResultado = True
                        Me.Close()
                    End If
                Next
            End If
        End With

    End Sub

    Private Sub consulta()

        Dim sConsulta As String = String.Empty
        Dim dsTemp As New DataSet

        If Me.txtSigla.Text <> String.Empty OrElse Me.txtEmpresa.Text <> String.Empty Then
            'Copia a estrutura do dataset para o dataset temporário
            dsTemp = Me.dsEmpresasSelecionadas.Clone

            If Me.txtSigla.Text <> String.Empty AndAlso Me.txtEmpresa.Text <> String.Empty Then
                sConsulta = "Sigla LIKE '" & Me.txtSigla.Text & "%'"
                sConsulta &= " AND NomeFantasia LIKE '" & Me.txtEmpresa.Text & "%'"

            ElseIf Me.txtSigla.Text <> String.Empty AndAlso Me.txtEmpresa.Text = String.Empty Then
                sConsulta = "Sigla LIKE '" & Me.txtSigla.Text & "%'"

            ElseIf Me.txtSigla.Text = String.Empty AndAlso Me.txtEmpresa.Text <> String.Empty Then
                sConsulta = "NomeFantasia LIKE '" & Me.txtEmpresa.Text & "%'"
            End If

            'Para cada linha retornada da consulta insere o seu resultado no dataset temporário
            For Each drDados As DataRow In Me.dsEmpresasSelecionadas.Tables(0).Select(sConsulta)
                dsTemp.Tables(0).Rows.Add(New Object() {drDados.Item("IDEmpresa"), _
                                                        drDados.Item("Sigla"), _
                                                        drDados.Item("NomeFantasia")})
            Next

            'Preenche o grid com apenas os dados relativos a consulta
            Me.PreencherDtGrid(dsTemp)

        Else
            'Se não foi inserido nenhum valor para a consulta preenche o grid com todos os dados
            Me.PreencherDtGrid(Me.dsEmpresasSelecionadas)
        End If

    End Sub

    Private Sub txtSigla_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSigla.TextChanged
        Me.consulta()
    End Sub

    Private Sub txtEmpresa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpresa.TextChanged
        Me.consulta()
    End Sub

    Private Sub frmSelecionarEmpresa_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

    End Sub
End Class