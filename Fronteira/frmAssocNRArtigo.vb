Imports Persistencia
Public Class frmAssocNRArtigo

#Region " Variáveis"
    Private objNR As New Controle.ctrNR
    Private dtsDadosArtigoNR As New DataSet
    Private iIdNR As Integer
    Private datArtigos As DataTable
#End Region

#Region " Enumerações "

    Private Enum eColunasArtigos
        ArtigoCompleto = 0
        Artigo = 1
        Letra = 2
        Texto = 3
        Penalidade = 4
        Aplicavel = 5
        IDArtigo = 6
    End Enum

#End Region

#Region " Propriedades "

    Public Property IDNR As Integer
        Get
            Return Me.iIdNR
        End Get
        Set(ByVal value As Integer)
            Me.iIdNR = value
        End Set
    End Property

    Public Property DadosArtigoNR As DataSet
        Get
            Return Me.dtsDadosArtigoNR
        End Get
        Set(ByVal value As DataSet)
            Me.dtsDadosArtigoNR = value
        End Set
    End Property

#End Region

#Region " Métodos "

    Private Sub frmAssocNRArtigo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.configurarGrid()
        Me.preencherGrid()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click

        Me.excluirArtigosNR()
        Me.incluirArtigosNR()

        Me.Close()

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click

        Me.Close()

    End Sub

    Private Sub configurarGrid()

        Try

            With Me.dgvArtigos

                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = True
                .RowHeadersVisible = True
                .RowHeadersWidth = 20
                .Columns.Clear()

                Dim Col_Artigo_Completo As New DataGridViewTextBoxColumn()
                Col_Artigo_Completo.HeaderText = "ArtigoCompleto"
                Col_Artigo_Completo.DataPropertyName = "ArtigoCompleto"
                Col_Artigo_Completo.Width = 50
                Col_Artigo_Completo.Frozen = False
                Col_Artigo_Completo.ReadOnly = True
                Col_Artigo_Completo.FillWeight = 50
                Col_Artigo_Completo.SortMode = DataGridViewColumnSortMode.Automatic
                Col_Artigo_Completo.Visible = False
                Col_Artigo_Completo.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col_Artigo_Completo)

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "Artigo"
                Col1.DataPropertyName = "CodArtigo"
                Col1.Width = 50
                Col1.Frozen = False
                Col1.ReadOnly = True
                Col1.FillWeight = 50
                Col1.SortMode = DataGridViewColumnSortMode.Automatic
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.string")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Letra"
                Col2.DataPropertyName = "Letra"
                Col2.Width = 40
                Col2.Frozen = False
                Col2.ReadOnly = True
                Col2.FillWeight = 40
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.String")
                Col2.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Texto"
                Col3.DataPropertyName = "Texto"
                Col3.Width = 360
                Col3.Frozen = False
                Col3.ReadOnly = True
                Col3.FillWeight = 360
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                Col3.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Cód. Penalidade"
                Col4.DataPropertyName = "Penalidade"
                Col4.Width = 80
                Col4.Frozen = False
                Col4.ReadOnly = True
                Col4.FillWeight = 80
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewCheckBoxColumn()
                Col5.HeaderText = "Aplicável"
                Col5.DataPropertyName = "Aplicável"
                Col5.Width = 60
                Col5.Frozen = False
                Col5.ReadOnly = False
                Col5.FillWeight = 60
                Col5.Visible = True
                Col5.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col5)

                Dim Col6 As New DataGridViewTextBoxColumn()
                Col6.HeaderText = "IDArtigo"
                Col6.DataPropertyName = "IDArtigo"
                Col6.Width = 110
                Col6.Frozen = False
                Col6.ReadOnly = True
                Col6.FillWeight = 60
                Col6.Visible = False
                Col6.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col6)

                .Refresh()

            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub preencherGrid()

        Dim sArtigo As String = String.Empty
        Dim sLetra As String = String.Empty
        Dim iLinha As Integer = 0

        Try

            Me.datArtigos = Me.objNR.Selecionar_Artigos_NR(Me.IDNR)

            If Me.datArtigos.Rows.Count > 0 Then

                With Me.dgvArtigos

                    .Rows.Clear()

                    .RowCount = datArtigos.Rows.Count

                    For Each drDados As DataRow In datArtigos.Rows
                        sArtigo = drDados.Item("CodArtigo")
                        sLetra = drDados.Item("Letra")
                        .Item(eColunasArtigos.Artigo, iLinha).Value = sArtigo
                        .Item(eColunasArtigos.Letra, iLinha).Value = sLetra
                        .Item(eColunasArtigos.ArtigoCompleto, iLinha).Value = Me.retornarArtigoCompleto(sArtigo, sLetra)
                        .Item(eColunasArtigos.Texto, iLinha).Value = drDados.Item("Texto").ToString
                        .Item(eColunasArtigos.Penalidade, iLinha).Value = drDados.Item("Penalidade").ToString
                        .Item(eColunasArtigos.Aplicavel, iLinha).Value = False
                        .Item(eColunasArtigos.IDArtigo, iLinha).Value = drDados.Item("IDArtigo")
                        iLinha += 1
                    Next

                    .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                End With

                Me.atualizarArtigosNR()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub excluirArtigosNR()

        Dim drDadosNR As DataRow()

        drDadosNR = Me.DadosArtigoNR.Tables(0).Select("IDEmpresa = " & Globais.iIDEmpresa & " AND " & " IDNR = " & Me.IDNR)

        If drDadosNR.Length > 0 Then

            Me.DadosArtigoNR.BeginInit()

            For iCont As Integer = 0 To drDadosNR.Length - 1
                drDadosNR(iCont).Delete()
            Next

            Me.DadosArtigoNR.EndInit()
            Me.DadosArtigoNR.AcceptChanges()

        End If

    End Sub

    Private Sub incluirArtigosNR()

        Dim drNovaLinha As DataRow

        For Each drDados As DataGridViewRow In Me.dgvArtigos.Rows

            If Persistencia.Conversao.ToBoolean(drDados.Cells(eColunasArtigos.Aplicavel).Value) Then

                drNovaLinha = Me.DadosArtigoNR.Tables(0).NewRow
                drNovaLinha.Item("IDEmpresa") = Persistencia.Globais.iIDEmpresa
                drNovaLinha.Item("IDNR") = Me.IDNR
                drNovaLinha.Item("IDArtigo") = drDados.Cells(eColunasArtigos.IDArtigo).Value

                Me.DadosArtigoNR.Tables(0).Rows.Add(drNovaLinha)

            End If

        Next

    End Sub

    Private Sub atualizarArtigosNR()

        For Each drDados As DataGridViewRow In Me.dgvArtigos.Rows

            If Me.DadosArtigoNR.Tables(0).Select("IDEmpresa = " & Globais.iIDEmpresa & " AND " &
                                                 "IDArtigo = " & drDados.Cells(eColunasArtigos.IDArtigo).Value).Length > 0 Then

                Me.dgvArtigos.Item(eColunasArtigos.Aplicavel, drDados.Index).Value = True

            End If

        Next

    End Sub

    Private Function retornarArtigoCompleto(ByVal sArtigo As String,
                                                ByVal sLetra As String) As String

        Dim sArtigoCompleto As String = String.Empty
        Dim vetArtigo As String()
        Dim sArtigoTemp As String

        'Formata o artigo com a letra para ordenação do gridd

        vetArtigo = sArtigo.Split(".")
        For i As Integer = 0 To vetArtigo.GetUpperBound(0)
            sArtigoTemp = "000000" & vetArtigo(i)
            sArtigoTemp = sArtigoTemp.Substring(sArtigoTemp.Length - 5)
            sArtigoCompleto &= sArtigoTemp
        Next

        If (sLetra <> String.Empty) Then
            sArtigoCompleto &= sLetra
        Else
            sArtigoCompleto &= "0"
        End If

        Return sArtigoCompleto

    End Function

#End Region


End Class