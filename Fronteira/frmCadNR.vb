Imports Controle
Imports System.IO
Imports Persistencia
Imports Controle.ctrNR
Public Class frmCadNR

#Region "Variáveis"
    Private iPrvIDNr As Integer
    Private objNR As New ctrNR
    Private iIDNRAntigo As Integer
#End Region

#Region "Métodos"

    Private Sub Configurar_Grid()
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
                Col3.Width = 370
                Col3.Frozen = False
                Col3.ReadOnly = True
                Col3.FillWeight = 370
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                Col3.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Cód. Penalidade"
                Col4.DataPropertyName = "Penalidade"
                Col4.Width = 110
                Col4.Frozen = False
                Col4.ReadOnly = True
                Col4.FillWeight = 105
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewTextBoxColumn()
                Col5.HeaderText = "IDArtigo"
                Col5.DataPropertyName = "IDArtigo"
                Col5.Width = 110
                Col5.Frozen = False
                Col5.ReadOnly = True
                Col5.FillWeight = 105
                Col5.Visible = False
                Col5.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col5)

                .Refresh()

            End With

            With Me.dgvQuestoes
                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = True
                .RowHeadersWidth = 20
                .Columns.Clear()
                .Rows.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "IDQuestao"
                Col1.DataPropertyName = "IDQuestao"
                Col1.Width = 60
                Col1.Frozen = False
                Col1.ReadOnly = True
                Col1.FillWeight = 60
                Col1.SortMode = DataGridViewColumnSortMode.Automatic
                Col1.Visible = False
                Col1.ValueType = System.Type.GetType("System.integer")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "CodArtigo"
                Col2.DataPropertyName = "CodArtigo"
                Col2.Width = 60
                Col2.Frozen = False
                Col2.ReadOnly = True
                Col2.FillWeight = 60
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = False
                Col2.ValueType = System.Type.GetType("System.integer")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Questão"
                Col3.DataPropertyName = "Questao"
                Col3.Width = 300
                Col3.Frozen = False
                Col3.ReadOnly = True
                Col3.Visible = True
                Col3.FillWeight = 300
                Col3.ValueType = System.Type.GetType("System.String")
                Col3.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Ação"
                Col4.DataPropertyName = "Acao"
                Col4.Width = 257
                Col4.FillWeight = 257
                Col4.Frozen = False
                Col4.ReadOnly = True
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                Col4.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Add(Col4)

                Dim icoAdicionar As New Icon(Me.GetType(), "Adicionar.ico")
                Dim Col5 As New DataGridViewImageColumn()
                With Col5
                    .HeaderText = ""
                    .Width = 20
                    .Frozen = False
                    .ReadOnly = False
                    .FillWeight = 20
                    .Visible = True
                    .Icon = icoAdicionar
                    .ValueType = Nothing
                    .ValuesAreIcons = True
                End With
                .Columns.Add(Col5)

                Dim icoExcluir As New Icon(Me.GetType(), "Excluir2.ico")
                Dim Col6 As New DataGridViewImageColumn
                With Col6
                    .HeaderText = ""
                    .Width = 20
                    .Frozen = False
                    .ReadOnly = False
                    .FillWeight = 20
                    .Visible = True
                    .Icon = icoExcluir
                    .ValueType = Nothing
                    .ValuesAreIcons = True
                End With
                .Columns.Add(Col6)

                Dim Col7 As New DataGridViewLinkColumn
                With Col7
                    .HeaderText = "Evidência"
                    .Width = 160
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col7)

                Dim Col8 As New DataGridViewTextBoxColumn()
                With Col8
                    .HeaderText = "IDArquivo"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col8)

                Dim Col9 As New DataGridViewTextBoxColumn()
                With Col9
                    .HeaderText = "DescricaoDocumento"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col9)

                Dim Col10 As New DataGridViewTextBoxColumn
                With Col10
                    .HeaderText = "Arquivo"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Byte[]")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col10)
                .Refresh()

                Dim Col11 As New DataGridViewTextBoxColumn()
                With Col11
                    .HeaderText = "IDDocumento"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col11)

                .Rows.Clear()
                .Refresh()

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub Exibir_Tela_Artigos(ByRef sCodArtigo As String, _
                                    ByRef sLetra As String, _
                                    ByRef sArtigo As String, _
                                    ByRef sPenalidade As String)

        With frmArtigo
            .ArtigoAntigo = sCodArtigo
            .Texto = sArtigo
            .Penalidade = sPenalidade
            .Letra = sLetra

            .Carregar_Tela()
            .ShowDialog()
            If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                sCodArtigo = .ArtigoNovo.ToString.Trim
                sArtigo = .Texto.ToString.Trim
                sPenalidade = .Penalidade.ToString.Trim
                sLetra = .Letra.ToString.Trim
            End If
        End With

        frmArtigo = Nothing

    End Sub

    Private Sub Mostrar_Questoes()
        Dim Selecionadas As DataGridViewSelectedRowCollection
        Dim sArtigo As String = ""

        Try
            If (dgvArtigos.SelectedRows.Count > 0) Then
                Selecionadas = dgvArtigos.SelectedRows

                If Selecionadas.Count = 1 Then
                    sArtigo = Selecionadas.Item(0).Cells(eColunasArtigos.Artigo).Value
                End If

                If (sArtigo <> String.Empty) Then
                    With dgvQuestoes
                        For i As Integer = 0 To dgvQuestoes.Rows.Count - 1
                            .Rows(i).Visible = CBool((Trim(.Item(eColunasQuestoes.IDArtigo, i).Value) = sArtigo))
                        Next
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Function Validar_Artigos() As Boolean
        Dim dsGrid As New DataSet
        Dim sArtigo As String
        Dim sPai As String
        Dim i As Integer
        Dim j As Integer
        Dim bRetorno As Boolean = True
        Dim bEncontrado As Boolean

        Try
            With dgvArtigos
                For i = .Rows.Count - 1 To 0 Step -1
                    sArtigo = .Item(eColunasArtigos.Artigo, i).Value
                    sPai = Me.Retornar_Pai_Artigo(sArtigo)

                    If (sPai <> "") Then
                        bEncontrado = False
                        For j = i To 0 Step -1
                            If (.Item(eColunasArtigos.Artigo, j).Value = sPai) Then
                                bEncontrado = True
                                Exit For
                            End If
                        Next

                        If (Not bEncontrado) Then
                            bRetorno = False
                            Exit For
                        End If
                    End If
                Next

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        Return bRetorno

    End Function

    Private Sub Editar_Questao(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim sQuestao As String = ""
        Dim sAcao As String = ""
        Dim sArtigo As String = ""
        Dim iArtigoSelecionado As Integer = 0

        Try
            If (dgvArtigos.Rows.Count > 0) Then
                iArtigoSelecionado = dgvArtigos.CurrentRow.Index
                sArtigo = dgvArtigos.Item(eColunasArtigos.Artigo, iArtigoSelecionado).Value

                If (e.RowIndex >= 0) Then
                    With frmQuestao
                        .Questao = dgvQuestoes.Item(eColunasQuestoes.Questao, e.RowIndex).Value.ToString.Trim
                        .Acao = dgvQuestoes.Item(eColunasQuestoes.Acao, e.RowIndex).Value.ToString.Trim
                        .Artigo = sArtigo
                        .Carregar_Tela()

                        If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                            sQuestao = .Questao.ToString.Trim
                            sAcao = .Acao.ToString.Trim

                            If (sQuestao <> String.Empty) Then
                                With dgvQuestoes
                                    .Item(eColunasQuestoes.IDArtigo, e.RowIndex).Value = sArtigo
                                    .Item(eColunasQuestoes.Questao, e.RowIndex).Value = sQuestao
                                    .Item(eColunasQuestoes.Acao, e.RowIndex).Value = sAcao
                                End With
                            End If
                        End If

                    End With
                    frmQuestao = Nothing
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Function Retornar_Artigo_Completo(ByVal sArtigo As String, _
                                              ByVal sLetra As String) As String

        Dim sArtigoCompleto As String = ""
        Dim vetArtigo As String()
        Dim sArtigoTemp As String

        'Formata o artigo com a letra para ordenação do gridd

        vetArtigo = sArtigo.Split(".")
        For i As Integer = 0 To UBound(vetArtigo)
            sArtigoTemp = "000000" & vetArtigo(i)
            sArtigoTemp = sArtigoTemp.Substring(sArtigoTemp.Length - 5)
            sArtigoCompleto &= sArtigoTemp
        Next

        If (sLetra <> "") Then
            sArtigoCompleto &= sLetra
        Else
            sArtigoCompleto &= "0"
        End If

        Return sArtigoCompleto

    End Function

    Private Function Retornar_Pai_Artigo(ByVal sArtigo As String) As String
        Dim sPai As String

        sPai = sArtigo.Substring(0, InStrRev(sArtigo, "."))
        If (sPai <> "") Then
            sPai &= "0"
        End If
        Return IIf(sPai = sArtigo, "", sPai)

    End Function

    Private Function Validar_CodArtigo(ByVal sCodArtigo As String, _
                                       ByVal sLetra As String, _
                                       ByVal bEdicao As String)
        Dim iArtigos As Integer = 0
        Dim sArtigo As String
        Dim sArtigoCompleto As String = ""

        With dgvArtigos
            For cont As Integer = 0 To .RowCount - 1

                sArtigo = .Item(eColunasArtigos.ArtigoCompleto, cont).Value
                sArtigoCompleto = Retornar_Artigo_Completo(sCodArtigo, sLetra)
                If (sArtigo = sArtigoCompleto) Then
                    If (bEdicao) Then
                        iArtigos += 1
                    Else
                        iArtigos = 2
                    End If
                    If (iArtigos > 1) Then
                        Exit For
                    End If
                End If
            Next

        End With

        If (iArtigos > 1) Then
            MsgBox("Código do artigo já utilizado. Verifique.")
        End If

        Return iArtigos <= 1

    End Function

#End Region

#Region "Métodos do formulário"

    Private Sub frmCadNR_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        txtNR.Enabled = (eModoAtual = eModo.eAlterando)
        cmdSelecionarNR.Enabled = (eModoAtual = eModo.eAguardando)
        txtDescricao.Enabled = (eModoAtual = eModo.eAlterando)
        cmdAdicionarArtigo.Enabled = (eModoAtual = eModo.eAlterando)
        cmdExcluirArtigo.Enabled = (eModoAtual = eModo.eAlterando)
        cmdAdicionarPergunta.Enabled = (eModoAtual = eModo.eAlterando)
        cmdExcluirPergunta.Enabled = (eModoAtual = eModo.eAlterando)
    End Sub

    Private Sub frmCadNR_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados
        Dim dtbArtigos As New DataTable
        Dim dtbQuestoes As New DataTable
        Dim sArtigo As String = ""
        Dim sLetra As String = ""
        Dim cont As Integer = 0

        Try

            If (Me.iPrvIDNr > 0) Then

                Me.iIDNRAntigo = Me.iPrvIDNr
                Me.txtNR.Text = Me.iPrvIDNr
                Me.txtDescricao.Text = Persistencia.Conversao.nuloParaVazio(objNR.selecionarCampo(Me.iPrvIDNr, "descricao"))

                dtbArtigos = objNR.Selecionar_Artigos_NR(Me.iPrvIDNr)
                dtbQuestoes = objNR.Selecionar_Questoes_NR(Me.iPrvIDNr)

                With dgvArtigos
                    .Rows.Clear()
                    If (dtbArtigos.Rows.Count > 0) Then
                        .RowCount = dtbArtigos.Rows.Count

                        For Each drDados As DataRow In dtbArtigos.Rows
                            sArtigo = drDados.Item("CodArtigo").ToString
                            .Item(eColunasArtigos.Artigo, cont).Value = sArtigo
                            sLetra = drDados.Item("Letra").ToString
                            .Item(eColunasArtigos.Letra, cont).Value = sLetra
                            .Item(eColunasArtigos.ArtigoCompleto, cont).Value = Retornar_Artigo_Completo(sArtigo, sLetra)
                            .Item(eColunasArtigos.Texto, cont).Value = drDados.Item("Texto").ToString
                            .Item(eColunasArtigos.Penalidade, cont).Value = drDados.Item("Penalidade").ToString
                            .Item(eColunasArtigos.IDArtigo, cont).Value = drDados.Item("IDArtigo").ToString
                            cont += 1
                        Next

                    End If
                    .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End With

                With dgvQuestoes
                    .Rows.Clear()
                    cont = 0
                    If (dtbQuestoes.Rows.Count > 0) Then
                        .RowCount = dtbQuestoes.Rows.Count

                        For Each drDados As DataRow In dtbQuestoes.Rows
                            sArtigo = Persistencia.Conversao.nuloParaVazio(drDados.Item("CodArtigo").ToString)
                            .Item(eColunasQuestoes.IDArtigo, cont).Value = sArtigo
                            .Item(eColunasQuestoes.Questao, cont).Value = Persistencia.Conversao.nuloParaVazio(drDados.Item("Questao").ToString)
                            .Item(eColunasQuestoes.Acao, cont).Value = Persistencia.Conversao.nuloParaVazio(drDados.Item("Acao").ToString)

                            .Item(eColunasQuestoes.Evidencia, cont).Value = Conversao.nuloParaVazio(drDados.Item("NomeArquivo"))
                            .Item(eColunasQuestoes.IDItemCheckList, cont).Value = Conversao.ToInt32(drDados.Item("IDArquivo"))
                            .Item(eColunasQuestoes.DescricaoDocumento, cont).Value = Conversao.nuloParaVazio(drDados.Item("DescricaoArquivo"))
                            If Not drDados.Item("Arquivo") Is DBNull.Value Then
                                .Item(eColunasQuestoes.Arquivo, cont).Value = drDados.Item("Arquivo")
                            End If
                            .Item(eColunasQuestoes.IDDocumento, cont).Value = Conversao.ToInt32(drDados.Item("IDDocumento"))

                            .Rows(cont).Visible = False
                            cont += 1
                        Next
                        dgvArtigos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        dgvArtigos.MultiSelect = False
                        Me.Mostrar_Questoes()
                    End If
                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCadNR_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objNR.Excluir_NR(Me.iPrvIDNr) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados a NR que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                Else
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvIDNr = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCadNR_gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim bRetorno As Boolean
        Dim dsArtigos As New DataSet
        Dim dsQuestoes As New DataSet

        Try

            bCancel = True

            dsArtigos = Persistencia.Conversao.converteGridParaDataset(dgvArtigos)
            dsQuestoes = Persistencia.Conversao.converteGridParaDataset(dgvQuestoes)

            'If (Validar_Artigos()) Then

            'End If

            bRetorno = Me.objNR.Salvar(Conversao.ToInt32(Me.txtNR.Text),
                                       Me.txtDescricao.Text.Trim,
                                       dsArtigos,
                                       dsQuestoes,
                                       Me.iIDNRAntigo)

            If (bRetorno) Then
                bCancel = False
                Me.iPrvIDNr = Me.objNR.IDNR
                MyBase.chave = Me.iPrvIDNr
            Else
                MyBase.Mensagens = objNR.retornaMensagensValidacao
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCadNR_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Me.iIDNRAntigo = 0
    End Sub

    Private Sub frmCadNR_limpaCampo() Handles Me.limpaCampo

        Me.txtNR.Text = String.Empty
        Me.txtDescricao.Text = String.Empty

        Me.dgvArtigos.DataSource = Nothing
        Me.dgvQuestoes.DataSource = Nothing

        Me.dgvArtigos.Rows.Clear()
        Me.dgvQuestoes.Rows.Clear()

    End Sub

    Private Sub frmCadNR_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        Me.epPadrao.Clear()
    End Sub

    Private Sub frmCadNR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Configurar_Grid()
    End Sub

    Private Sub cmdAdicionarArtigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarArtigo.Click

        Dim sArtigo As String = ""
        Dim sTexto As String = ""
        Dim sPenalidade As String = ""
        Dim sLetra As String = ""

        Try
            Me.Exibir_Tela_Artigos(sArtigo, sLetra, sTexto, sPenalidade)

            If (Validar_CodArtigo(sArtigo, sLetra, False)) Then

                If (sArtigo <> String.Empty And sTexto <> String.Empty) Then
                    With dgvArtigos
                        .Rows.Add()
                        .Item(eColunasArtigos.ArtigoCompleto, .Rows.Count - 1).Value = Retornar_Artigo_Completo(sArtigo, sLetra)
                        .Item(eColunasArtigos.Artigo, .Rows.Count - 1).Value = sArtigo
                        .Item(eColunasArtigos.Letra, .Rows.Count - 1).Value = sLetra
                        .Item(eColunasArtigos.Texto, .Rows.Count - 1).Value = sTexto
                        .Item(eColunasArtigos.Penalidade, .Rows.Count - 1).Value = sPenalidade
                        .Item(eColunasArtigos.IDArtigo, .Rows.Count - 1).Value = 0
                        .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    End With
                End If
            Else
                Me.Exibir_Tela_Artigos("", sLetra, sTexto, sPenalidade)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub exportarDocumentos(ByVal Arquivo As Byte(), _
                                   ByVal sNomeArquivo As String)
        Dim fs As FileStream
        Dim sCaminhoSelecionado As String
        Dim bits As Byte() = {0}
        Dim memorybits As MemoryStream

        Try
            Dim openDlg As FolderBrowserDialog = New FolderBrowserDialog
            openDlg.ShowNewFolderButton = True

            If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                sCaminhoSelecionado = openDlg.SelectedPath

                bits = CType(Arquivo, Byte())
                sNomeArquivo = sNomeArquivo
                memorybits = New MemoryStream(bits)

                fs = New FileStream(sCaminhoSelecionado & "\" & sNomeArquivo, FileMode.Create, FileAccess.Write)
                fs.Write(bits, 0, bits.Length)
                fs.Close()

                MsgBox("O documento foi exportado com sucesso.", MsgBoxStyle.Information, Me.Text)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub dgvArtigos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArtigos.CellDoubleClick
        Dim sTexto As String = ""
        Dim sPenalidade As String = ""
        Dim sLetra As String = ""
        Dim sArtigoNovo As String
        Dim sArtigoAntigo As String
        Dim sLetraAntiga As String

        Try
            If (Me.modoAtual = eModo.eAlterando) Then
                If (e.RowIndex >= 0) Then
                    With frmArtigo
                        sArtigoAntigo = dgvArtigos.Item(eColunasArtigos.Artigo, e.RowIndex).Value.ToString.Trim
                        .ArtigoAntigo = sArtigoAntigo
                        .Texto = dgvArtigos.Item(eColunasArtigos.Texto, e.RowIndex).Value.ToString.Trim
                        .Penalidade = dgvArtigos.Item(eColunasArtigos.Penalidade, e.RowIndex).Value.ToString.Trim
                        sLetraAntiga = dgvArtigos.Item(eColunasArtigos.Letra, e.RowIndex).Value.ToString.Trim
                        .Letra = sLetraAntiga
                        .Carregar_Tela()
                        .ShowDialog()
                        If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                            sArtigoNovo = .ArtigoNovo.ToString.Trim
                            sTexto = .Texto.ToString.Trim
                            sPenalidade = .Penalidade.ToString.Trim
                            sLetra = .Letra.ToString.Trim

                            If (sArtigoNovo <> String.Empty And sTexto <> String.Empty) Then
                                With dgvArtigos
                                    .Item(eColunasArtigos.ArtigoCompleto, e.RowIndex).Value = Retornar_Artigo_Completo(sArtigoNovo, sLetra)
                                    .Item(eColunasArtigos.Artigo, e.RowIndex).Value = sArtigoNovo
                                    .Item(eColunasArtigos.Texto, e.RowIndex).Value = sTexto
                                    .Item(eColunasArtigos.Penalidade, e.RowIndex).Value = sPenalidade
                                    .Item(eColunasArtigos.Letra, e.RowIndex).Value = sLetra
                                    .Item(eColunasArtigos.ArtigoCompleto, e.RowIndex).Value = Retornar_Artigo_Completo(sArtigoNovo, sLetra)
                                    .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                                End With
                                sArtigoAntigo = Retornar_Artigo_Completo(sArtigoAntigo, sLetraAntiga)
                                sArtigoNovo = Retornar_Artigo_Completo(sArtigoNovo, sLetra)
                                If (sArtigoAntigo.Trim <> sArtigoNovo.Trim) Then
                                    For iLinha As Integer = 0 To dgvQuestoes.RowCount - 1
                                        If (dgvQuestoes.Item(eColunasQuestoes.IDArtigo, iLinha).Value.trim = sArtigoAntigo) Then
                                            dgvQuestoes.Item(eColunasQuestoes.IDArtigo, iLinha).Value = sArtigoNovo.Trim
                                        End If
                                    Next
                                    Me.Mostrar_Questoes()
                                End If
                            End If
                        End If

                    End With
                    frmArtigo = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdExcluirArtigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirArtigo.Click

        Dim iLinha As Integer = 0
        Dim iIdArtigo As Integer = 0
        Dim bPermiteExcluirArtigo As Boolean = False

        Try

            If Me.dgvArtigos.Rows.Count > 0 Then

                iLinha = Me.dgvArtigos.CurrentRow.Index
                iIdArtigo = Conversao.ToInt32(Me.dgvArtigos.CurrentRow.Cells(eColunasArtigos.IDArtigo).Value)
                bPermiteExcluirArtigo = Me.objNR.sePermiteExcluirArtigo(iIdArtigo)

                If bPermiteExcluirArtigo AndAlso iLinha >= 0 Then

                    Me.dgvArtigos.Rows.Remove(Me.dgvArtigos.Rows(iLinha))

                    Me.dgvArtigos.Sort(Me.dgvArtigos.Columns(eColunasArtigos.ArtigoCompleto),
                                       System.ComponentModel.ListSortDirection.Ascending)

                ElseIf Not bPermiteExcluirArtigo Then
                    MessageBox.Show("Exclusão não permitida. Artigo vinculado à empresa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdAdicionarPergunta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarPergunta.Click
        Dim sQuestao As String = ""
        Dim sAcao As String = ""
        Dim sArtigo As String = ""
        Dim sLetra As String = ""
        Dim iArtigoSelecionado As Integer = 0

        Try
            If (dgvArtigos.Rows.Count > 0) Then
                iArtigoSelecionado = dgvArtigos.CurrentRow.Index

                If (iArtigoSelecionado >= 0) Then
                    sArtigo = dgvArtigos.Item(eColunasArtigos.Artigo, iArtigoSelecionado).Value
                    sLetra = dgvArtigos.Item(eColunasArtigos.Letra, iArtigoSelecionado).Value

                    With frmQuestao
                        .Questao = String.Empty
                        .Acao = String.Empty
                        .Artigo = sArtigo
                        .Letra = sLetra

                        .Carregar_Tela()

                        If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                            sQuestao = .Questao.ToString.Trim
                            sAcao = .Acao.ToString.Trim

                            If (sQuestao <> String.Empty) Then
                                With dgvQuestoes
                                    .Rows.Add()
                                    .Item(eColunasQuestoes.IDArtigo, .Rows.Count - 1).Value = sArtigo
                                    .Item(eColunasQuestoes.Questao, .Rows.Count - 1).Value = sQuestao
                                    .Item(eColunasQuestoes.Acao, .Rows.Count - 1).Value = sAcao
                                End With
                            End If
                        End If

                    End With

                    frmQuestao = Nothing

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdExcluirPergunta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirPergunta.Click
        Dim iLinha As Integer

        Try
            If (dgvQuestoes.Rows.Count > 0) Then
                iLinha = dgvQuestoes.CurrentRow.Index
                If (iLinha >= 0) Then
                    dgvQuestoes.Rows.Remove(dgvQuestoes.Rows(iLinha))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub dgvArtigos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArtigos.CellContentClick
        Dim sArtigo As String = ""

        Try

            If (e.RowIndex >= 0) Then
                Me.Mostrar_Questoes()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub dgvArtigos_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArtigos.RowEnter
        Dim sArtigo As String = ""

        Try

            If (e.RowIndex >= 0) Then
                sArtigo = Trim(dgvArtigos.Item(eColunasArtigos.ArtigoCompleto, e.RowIndex).Value)

                If (sArtigo <> String.Empty) Then
                    With dgvQuestoes
                        For i As Integer = 0 To dgvQuestoes.Rows.Count - 1
                            .Rows(i).Visible = CBool((Trim(.Item(eColunasQuestoes.IDArtigo, i).Value) = sArtigo))
                        Next
                    End With
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdSelecionarNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarNR.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objNR.sqlConsulta

        With frmDialogo
            .Campos = "iIDNR,sDescricao"
            .Descricoes = "NR,Descrição"
            .Larguras = "50,300"
            .Sql = sSql
            .Titulo = "Pesquisa NR"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    MyBase.chave = Persistencia.Conversao.ToString(.ID)
                    Me.iPrvIDNr = MyBase.chave
                    frmCadNR_carregaDados(Me.iPrvIDNr)
                    MyBase.alteraModopadrao(eModo.eAguardando)
                    frmCadNR_alteraModo(eModo.eAguardando)
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With
    End Sub

    Private Sub dgvQuestoes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuestoes.CellClick
        Select Case e.ColumnIndex

            Case eColunasQuestoes.Documento
                Dim frm As New frmDocumento

                frm.FormCheckList = True

                frm.DescricaoArquivo = Me.dgvQuestoes.Item(eColunasQuestoes.DescricaoDocumento, e.RowIndex).Value
                frm.NomeArquivo = Me.dgvQuestoes.Item(eColunasQuestoes.Evidencia, e.RowIndex).Value

                frm.ShowDialog()

                If frm.OK Then
                    Me.dgvQuestoes.Item(eColunasQuestoes.Evidencia, e.RowIndex).Value = frm.NomeArquivo
                    Me.dgvQuestoes.Item(eColunasQuestoes.DescricaoDocumento, e.RowIndex).Value = frm.DescricaoArquivo
                    Me.dgvQuestoes.Item(eColunasQuestoes.Arquivo, e.RowIndex).Value = frm.Arquivo
                End If

            Case eColunasQuestoes.Evidencia
                If Not String.IsNullOrEmpty(Me.dgvQuestoes.Item(eColunasQuestoes.Evidencia, e.RowIndex).Value) Then
                    Me.exportarDocumentos(Me.dgvQuestoes.Item(eColunasQuestoes.Arquivo, e.RowIndex).Value, _
                                          Me.dgvQuestoes.Item(eColunasQuestoes.Evidencia, e.RowIndex).Value)

                End If

            Case eColunasQuestoes.ExcluirDocumento
                Me.dgvQuestoes.Item(eColunasQuestoes.Evidencia, e.RowIndex).Value = String.Empty
                Me.dgvQuestoes.Item(eColunasQuestoes.DescricaoDocumento, e.RowIndex).Value = String.Empty

        End Select
    End Sub

    Private Sub dgvQuestoes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuestoes.CellDoubleClick
        Dim sQuestao As String = ""
        Dim sAcao As String = ""
        Dim sArtigo As String = ""
        Dim sLetra As String = ""
        Dim iArtigoSelecionado As Integer = 0

        Try
            If (Me.modoAtual = eModo.eAlterando) Then
                If (e.RowIndex >= 0) Then
                    iArtigoSelecionado = dgvArtigos.CurrentRow.Index

                    If (iArtigoSelecionado >= 0) Then
                        sArtigo = dgvArtigos.Item(eColunasArtigos.Artigo, iArtigoSelecionado).Value
                        sLetra = dgvArtigos.Item(eColunasArtigos.Letra, iArtigoSelecionado).Value
                        sQuestao = dgvQuestoes.Item(eColunasQuestoes.Questao, e.RowIndex).Value
                        sAcao = dgvQuestoes.Item(eColunasQuestoes.Acao, e.RowIndex).Value

                        With frmQuestao
                            .Questao = sQuestao
                            .Acao = sAcao
                            .Artigo = sArtigo
                            .Letra = sLetra

                            .Carregar_Tela()

                            If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                                sQuestao = .Questao.ToString.Trim
                                sAcao = .Acao.ToString.Trim

                                If (sQuestao <> String.Empty) Then
                                    With dgvQuestoes
                                        .Item(eColunasQuestoes.IDArtigo, e.RowIndex).Value = sArtigo
                                        .Item(eColunasQuestoes.Questao, e.RowIndex).Value = sQuestao
                                        .Item(eColunasQuestoes.Acao, e.RowIndex).Value = sAcao
                                    End With
                                End If
                            End If

                        End With

                        frmQuestao = Nothing

                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCadNR_setarProvedorDeErros() Handles Me.setarProvedorDeErros
        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case ctrNR.eMensagens.DESCRICAO_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtDescricao, sMensagem)
                Case ctrNR.eMensagens.NR_OBRIGATORIO
                    Me.epPadrao.SetError(Me.cmdSelecionarNR, sMensagem)
                Case ctrNR.eMensagens.NR_CADASTRADA
                    Me.epPadrao.SetError(Me.txtNR, sMensagem)
            End Select

        Next
    End Sub

#End Region

End Class