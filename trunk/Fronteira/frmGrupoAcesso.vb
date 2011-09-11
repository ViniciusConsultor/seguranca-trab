Imports Persistencia
Imports Controle.ctrGrupoAcesso
Public Class frmGrupoAcesso

#Region "Variáveis"

    Private objGrupoAcesso As New Controle.ctrGrupoAcesso
    Public iIDGrupoAcesso As Integer
    Private bResultado As Boolean

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

    ''' <summary>
    ''' Método privado que configura as colunas do grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub formataDtGrid()

        Try
            With Me.dgvGrupoAcesso

                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .AutoSize = False
                .ScrollBars = ScrollBars.Both

                .Columns.Clear()

                Dim treeIcon As New Icon(Me.GetType(), "expandido.ico")
                Dim Col1 As New DataGridViewImageColumn
                Col1.HeaderText = ""
                Col1.Width = 25
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                '        Col1.Frozen = True
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.ImageLayout = DataGridViewImageCellLayout.NotSet
                Col1.Visible = True
                Col1.ValuesAreIcons = True
                Col1.Icon = treeIcon
                Col1.Image = treeIcon.ToBitmap()
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn
                Col2.HeaderText = "Menu"
                Col2.Width = 250
                '       Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.NotSortable
                Col2.Visible = False
                Col2.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn
                Col3.HeaderText = "Nome"
                Col3.Width = 120
                '      Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 350
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.NotSortable
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewCheckBoxColumn()
                Col4.HeaderText = "Total"
                Col4.Width = 60
                '     Col4.Frozen = True
                Col4.ReadOnly = False
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col4.SortMode = DataGridViewColumnSortMode.NotSortable
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewCheckBoxColumn()
                Col5.HeaderText = "Inserir"
                Col5.Width = 60
                '    Col5.Frozen = True
                Col5.ReadOnly = False
                Col5.FillWeight = 100
                Col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col5.SortMode = DataGridViewColumnSortMode.NotSortable
                Col5.Visible = True
                Col5.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col5)

                Dim Col6 As New DataGridViewCheckBoxColumn()
                Col6.HeaderText = "Excluir"
                Col6.Width = 60
                '   Col6.Frozen = True
                Col6.ReadOnly = False
                Col6.FillWeight = 100
                Col6.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col6.SortMode = DataGridViewColumnSortMode.NotSortable
                Col6.Visible = True
                Col6.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col6)

                Dim Col7 As New DataGridViewCheckBoxColumn()
                Col7.HeaderText = "Alterar"
                Col7.Width = 60
                '  Col7.Frozen = True
                Col7.ReadOnly = False
                Col7.FillWeight = 100
                Col7.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col7.SortMode = DataGridViewColumnSortMode.NotSortable
                Col7.Visible = True
                Col7.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col7)

                Dim Col8 As New DataGridViewCheckBoxColumn()
                Col8.HeaderText = "Consultar"
                Col8.Width = 60
                ' Col8.Frozen = True
                Col8.ReadOnly = False
                Col8.FillWeight = 100
                Col8.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col8.SortMode = DataGridViewColumnSortMode.NotSortable
                Col8.Visible = True
                Col8.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col8)

                Dim Col9 As New DataGridViewCheckBoxColumn()
                Col9.HeaderText = "NodoPai"
                Col9.Width = 70
                'Col9.Frozen = True
                Col9.ReadOnly = False
                Col9.FillWeight = 100
                Col9.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col9.SortMode = DataGridViewColumnSortMode.NotSortable
                Col9.Visible = False
                Col9.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col9)

                Dim Col10 As New DataGridViewTextBoxColumn()
                Col10.HeaderText = "NodoFilho"
                Col10.Width = 70
                ' Col10.Frozen = True
                Col10.ReadOnly = False
                Col10.FillWeight = 100
                Col10.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col10.SortMode = DataGridViewColumnSortMode.NotSortable
                Col10.Visible = False
                Col10.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col10)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    ''' <summary>
    ''' Método privado que carrega no grid todos os menus do sistema
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub carregaMenu()

        Dim iLinha As Integer = 0
        Dim iContador As Integer = 0

        Me.formataDtGrid()

        Me.calcularQtdLinhas(frmPrincipal.MenuPrincipal.Items, iContador)

        With Me.dgvGrupoAcesso
            .Rows.Clear()
            .RowCount = iContador

            Me.listaMenu(frmPrincipal.MenuPrincipal.Items, _
                         iLinha, _
                         Color.Red, _
                         String.Empty, _
                         False)

        End With

    End Sub

    ''' <summary>
    ''' Método privado que calcula quantas linhas o grid irá possuir.
    ''' Realiza essa contagem através de uma iteração no menu do sistema,
    ''' contando todos os itens com seus respectivos subitens.
    ''' Necessário essa contagem porque no preenchimento do grid é obrigatório
    ''' antes de iniciar o preenchimento a informação de quantas linhas ele terá.
    ''' </summary>
    ''' <param name="toolStripItemCollection"></param>
    ''' <param name="iContador"></param>
    ''' <remarks></remarks>
    Private Sub calcularQtdLinhas(ByVal toolStripItemCollection As ToolStripItemCollection, _
                                  ByRef iContador As Integer)

        For Each Item As ToolStripItem In toolStripItemCollection

            If (TypeOf Item Is ToolStripMenuItem) Then
                Dim mi As ToolStripMenuItem = DirectCast(Item, ToolStripMenuItem)

                iContador += 1
                'Aqui faz uma chamada recursiva para buscar os menus filhos
                If (mi.DropDownItems.Count > 0) Then
                    calcularQtdLinhas(mi.DropDownItems, iContador)
                End If
            End If

        Next

    End Sub

    ''' <summary>
    ''' Método que preenche no grid os menus do sistema
    ''' </summary>
    ''' <param name="toolStripItemCollection">Coleção de itens do menu principal</param>
    ''' <param name="iLinha">Linha atual do grid que será preenchida</param>
    ''' <param name="forecolor">Cor da fonte da linha do grid</param>
    ''' <param name="sFilho">Quando for um menu filho irá preencher o nome do nó pai</param>
    ''' <param name="bNodoPai">Informação se é um menu pai</param>
    ''' <remarks></remarks>
    Private Sub listaMenu(ByVal toolStripItemCollection As ToolStripItemCollection, _
                          ByRef iLinha As Integer, _
                          ByVal forecolor As System.Drawing.Color, _
                          ByVal sFilho As String, _
                          ByVal bNodoPai As Boolean)

        'Iteração no menu principal do sistema
        For Each Item As ToolStripItem In toolStripItemCollection

            'Se o item for do tipo menu (podem ter outros tipos de itens como o separador)
            If (TypeOf Item Is ToolStripMenuItem) Then
                Dim mi As ToolStripMenuItem = DirectCast(Item, ToolStripMenuItem)

                'Se for um menu dropdown (for um menu filho)
                If Item.IsOnDropDown Then
                    'Obtem o nome do menu pai
                    sFilho = Item.OwnerItem.Name
                    bNodoPai = False
                Else
                    sFilho = String.Empty
                    bNodoPai = True
                End If

                'Insere a linha do menu no grid
                With Me.dgvGrupoAcesso
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eMenu, iLinha).Value = Item.Name
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNome, iLinha).Value = Item.Text
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eInserir, iLinha).Value = True
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eExcluir, iLinha).Value = True
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eAlterar, iLinha).Value = True
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eConsultar, iLinha).Value = True
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eTotal, iLinha).Value = True
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoPai, iLinha).Value = bNodoPai
                    .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoFilho, iLinha).Value = sFilho
                    .Rows(iLinha).DefaultCellStyle.ForeColor = forecolor
                End With

                iLinha += 1

                'Se for um menu pai com filhos faz uma chamada recursiva para inserir todo os seus filhos
                If (mi.DropDownItems.Count > 0) Then
                    listaMenu(mi.DropDownItems, iLinha, Color.Black, sFilho, bNodoPai)
                End If

            End If

        Next

    End Sub

    Private Sub configuraVisibilidadeExpansao()

        For iItem As Integer = 0 To Me.dgvGrupoAcesso.Rows.Count - 1
            If Conversao.ToBoolean(Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoPai.GetHashCode, iItem).Value) = False Then
                Dim treeIcon As New Icon(Me.GetType(), "branco.ico")
                Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eExpandir, iItem).Value = treeIcon
            Else
                Dim treeIcon As New Icon(Me.GetType(), "expandido.ico")
                Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eExpandir, iItem).Value = treeIcon
            End If
        Next

    End Sub

    Private Sub frmGrupoAcesso_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If eModoAtual = eModo.eAguardando Then
            Me.fraGeral.Enabled = False
            Me.cmdSelecionarGrupoAcesso.Enabled = True
        Else
            Me.fraGeral.Enabled = True
            Me.cmdSelecionarGrupoAcesso.Enabled = False
        End If

    End Sub

    ''' <summary>
    ''' Método que carrega no grid as configurações de um grupo de acesso já existente
    ''' </summary>
    ''' <param name="iChave"></param>
    ''' <remarks></remarks>
    Public Sub frmGrupoAcesso_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados

        Dim dsGrupoAcessoItem As New DataSet

        Try
            If (iChave > 0) Then

                'Preenche todos os menus do sistema
                Me.carregaMenu()

                dsGrupoAcessoItem = Me.objGrupoAcesso.selecionar(iChave)

                Me.txtDescricao.Text = dsGrupoAcessoItem.Tables(0).Rows(0).Item("Descricao")

                'Realiza uma iteração para cada linha do grid
                For iContador As Integer = 0 To Me.dgvGrupoAcesso.Rows.Count - 1
                    'A cada linha do grid, será feita uma iteração em com todas as linhas do dataset
                    For Each drDados As DataRow In dsGrupoAcessoItem.Tables(0).Rows
                        'Se o menu da linha atual do grid for o mesmo da linha atual do dataset, realiza o preenchimento
                        'das informações no grid
                        If Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eMenu, iContador).Value = drDados.Item("Menu") Then
                            Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eInserir, iContador).Value = Conversao.ToBoolean(drDados.Item("AcessoInserir"))
                            Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eExcluir, iContador).Value = Conversao.ToBoolean(drDados.Item("AcessoExcluir"))
                            Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eAlterar, iContador).Value = Conversao.ToBoolean(drDados.Item("AcessoAlterar"))
                            Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eConsultar, iContador).Value = Conversao.ToBoolean(drDados.Item("AcessoConsultar"))

                            If (Not Conversao.ToBoolean(drDados.Item("AcessoConsultar"))) OrElse (Not Conversao.ToBoolean(drDados.Item("AcessoInserir"))) _
                                OrElse (Not Conversao.ToBoolean(drDados.Item("AcessoExcluir"))) OrElse (Not Conversao.ToBoolean(drDados.Item("AcessoAlterar"))) Then
                                Me.dgvGrupoAcesso.Item(eColGrupoAcesso.eTotal, iContador).Value = False
                            End If
                        End If
                    Next
                Next

                MyBase.chave = iChave
                Me.idGrupoAcesso = iChave
                Me.configuraVisibilidadeExpansao()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmGrupoAcesso_gravar(ByRef bCancel As Boolean) Handles Me.gravar

        Dim bRetorno As Boolean
        Dim dsGrupoAcesso As New DataSet

        Try
            bCancel = True

            dsGrupoAcesso = MyBase.converteGridParaDataset(Me.dgvGrupoAcesso, "GrupoAcesso")

            bRetorno = Me.objGrupoAcesso.salvar(Me.iIDGrupoAcesso, _
                                                Me.txtDescricao.Text, _
                                                dsGrupoAcesso)

            If Not bRetorno Then

                MyBase.Mensagens = Me.objGrupoAcesso.retornaMensagensValidacao

            Else

                bCancel = False
                Me.iIDGrupoAcesso = Me.objGrupoAcesso.IDGrupoAcesso
                MyBase.chave = Me.objGrupoAcesso.IDGrupoAcesso
                Me.bResultado = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmGrupoAcesso_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try

            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objGrupoAcesso.excluir(Me.iIDGrupoAcesso) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                    bCancel = True
                Else
                    Me.iIDGrupoAcesso = 0
                End If
            Else
                MyBase.Mensagens = Me.objGrupoAcesso.retornaMensagensValidacao
                bCancel = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmGrupoAcesso_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case Controle.ctrGrupoAcesso.eMensagens.DESCRICAO_OBRIGATORIO
                    Me.epPadrao.SetError(Me.cmdSelecionarGrupoAcesso, sMensagem)
            End Select

        Next

    End Sub

    Private Sub frmGrupoAcesso_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        Me.epPadrao.SetError(Me.cmdSelecionarGrupoAcesso, String.Empty)
    End Sub

    Private Sub frmGrupoAcesso_limpaCampo() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)
    End Sub

    Private Sub frmGrupoAcesso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDescricao.Focus()
    End Sub

    Private Sub frmGrupoAcesso_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Me.iIDGrupoAcesso = 0
        Me.carregaMenu()
        Me.configuraVisibilidadeExpansao()
    End Sub

    Private Sub frmGrupoAcesso_alterar(ByRef bCancel As Boolean) Handles Me.alterar
        MyBase.modoAtual = eModo.eAlterando
    End Sub

    Private Sub cmdSelecionarGrupoAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarGrupoAcesso.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        Try
            sSql = Me.objGrupoAcesso.sqlConsulta()

            With frmDialogo
                .Sql = sSql
                .Titulo = "Pesquisa Grupo de Acesso"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Conversao.ToString(.ID)
                        Me.iIDGrupoAcesso = MyBase.chave
                        frmGrupoAcesso_carregaDados(MyBase.chave)
                        MyBase.alteraModopadrao(eModo.eAguardando)
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

    Private Sub frmGrupoAcesso_cancelar(ByRef bCancel As Boolean) Handles Me.cancelar
        Me.formataDtGrid()
    End Sub

    ''' <summary>
    ''' Método privado que configura a expansão das linhas filhas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvGrupoAcesso_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupoAcesso.CellClick

        Dim sIcon As String

        Try
            'Se a célula clicada é a célula de expansão e a linha for uma linha de menu pai
            If (Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoPai, e.RowIndex).Value) = True Then

                Select Case (Me.dgvGrupoAcesso.Item(e.ColumnIndex, e.RowIndex).ColumnIndex)

                    Case eColGrupoAcesso.eExpandir.GetHashCode

                        'Faz uma iteração no grid
                        For Each row As DataGridViewRow In Me.dgvGrupoAcesso.Rows

                            With Me.dgvGrupoAcesso

                                'Se a coluna a atual da iteração for filha da linha pai
                                If .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoFilho, row.Index).Value = .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eMenu, e.RowIndex).Value _
                                    AndAlso .Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoPai, row.Index).Value = False Then

                                    'Configura a visibilidade da linha filha
                                    .Rows.Item(row.Index).Visible = Not (.Rows.Item(row.Index).Visible)

                                    'Altera a imagem da célula de expansão de acordo com a visibilidade das linhas filhas
                                    If .Rows.Item(row.Index).Visible Then
                                        sIcon = "expandido.ico"
                                    Else
                                        sIcon = "expandir.ico"
                                    End If

                                    'Insere a imagem na célula de expansão da linha pai
                                    Dim treeIcon As New Icon(Me.GetType(), sIcon)
                                    .Item(e.ColumnIndex, e.RowIndex).Value = treeIcon

                                End If
                            End With

                        Next

                End Select


            End If

        Catch ex As Exception
            MsgBox("Erro: " & ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub dgvGrupoAcesso_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupoAcesso.CellEndEdit

        Try

            If (Me.dgvGrupoAcesso.Item(Controle.ctrGrupoAcesso.eColGrupoAcesso.eNodoPai, e.RowIndex).Value) = True Then

                Select Case (Me.dgvGrupoAcesso.Item(e.ColumnIndex, e.RowIndex).ColumnIndex)

                    Case eColGrupoAcesso.eTotal

                        For Each row As DataGridViewRow In Me.dgvGrupoAcesso.Rows

                            If Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eNodoFilho).Value = Me.dgvGrupoAcesso(eColGrupoAcesso.eMenu, e.RowIndex).Value Then
                                With Me.dgvGrupoAcesso
                                    .Rows(row.Index).Cells(eColGrupoAcesso.eAlterar).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                                    .Rows(row.Index).Cells(eColGrupoAcesso.eConsultar).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                                    .Rows(row.Index).Cells(eColGrupoAcesso.eExcluir).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                                    .Rows(row.Index).Cells(eColGrupoAcesso.eInserir).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                                    .Rows(row.Index).Cells(eColGrupoAcesso.eTotal).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                                End With
                            End If

                        Next

                    Case eColGrupoAcesso.eAlterar, eColGrupoAcesso.eExcluir, eColGrupoAcesso.eInserir

                        For Each row As DataGridViewRow In Me.dgvGrupoAcesso.Rows
                            If Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eNodoFilho).Value = Me.dgvGrupoAcesso(eColGrupoAcesso.eMenu, e.RowIndex).Value Then
                                If Me.dgvGrupoAcesso(e.ColumnIndex, e.RowIndex).Value = True Then
                                    Me.dgvGrupoAcesso(eColGrupoAcesso.eConsultar, row.Index).Value = True
                                Else
                                    Me.dgvGrupoAcesso(eColGrupoAcesso.eTotal, row.Index).Value = False
                                End If

                                Me.dgvGrupoAcesso(e.ColumnIndex, row.Index).Value = Me.dgvGrupoAcesso(e.ColumnIndex, e.RowIndex).Value

                            End If
                        Next

                    Case eColGrupoAcesso.eConsultar

                        For Each row As DataGridViewRow In Me.dgvGrupoAcesso.Rows
                            If Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eNodoFilho).Value = Me.dgvGrupoAcesso(eColGrupoAcesso.eMenu, e.RowIndex).Value Then

                                If Me.dgvGrupoAcesso(e.ColumnIndex, e.RowIndex).Value = False Then
                                    If Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eAlterar).Value = True OrElse _
                                       Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eExcluir).Value = True OrElse _
                                       Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eInserir).Value = True Then

                                        Me.dgvGrupoAcesso.Rows(row.Index).Cells(e.ColumnIndex).Value = True
                                    Else
                                        Me.dgvGrupoAcesso.Rows(row.Index).Cells(eColGrupoAcesso.eTotal).Value = False
                                        Me.dgvGrupoAcesso(e.ColumnIndex, row.Index).Value = False
                                    End If
                                Else
                                    Me.dgvGrupoAcesso(e.ColumnIndex, row.Index).Value = True
                                End If
                            End If
                        Next

                End Select
            End If

            Select Case (Me.dgvGrupoAcesso.Item(e.ColumnIndex, e.RowIndex).ColumnIndex)

                Case eColGrupoAcesso.eAlterar, eColGrupoAcesso.eExcluir, eColGrupoAcesso.eInserir

                    If Me.dgvGrupoAcesso(e.ColumnIndex, e.RowIndex).Value = True Then
                        Me.dgvGrupoAcesso(eColGrupoAcesso.eConsultar, e.RowIndex).Value = True
                    Else
                        Me.dgvGrupoAcesso(eColGrupoAcesso.eTotal, e.RowIndex).Value = False
                    End If

                Case eColGrupoAcesso.eConsultar

                    If Me.dgvGrupoAcesso(e.ColumnIndex, e.RowIndex).Value = False Then
                        If Me.dgvGrupoAcesso(eColGrupoAcesso.eAlterar, e.RowIndex).Value = True OrElse _
                           Me.dgvGrupoAcesso(eColGrupoAcesso.eExcluir, e.RowIndex).Value = True OrElse _
                           Me.dgvGrupoAcesso(eColGrupoAcesso.eInserir, e.RowIndex).Value = True Then

                            Me.dgvGrupoAcesso(e.ColumnIndex, e.RowIndex).Value = True
                        Else
                            Me.dgvGrupoAcesso(eColGrupoAcesso.eTotal, e.RowIndex).Value = False
                        End If
                    End If

                Case eColGrupoAcesso.eTotal

                    With Me.dgvGrupoAcesso
                        .Item(eColGrupoAcesso.eAlterar, e.RowIndex).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                        .Item(eColGrupoAcesso.eConsultar, e.RowIndex).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                        .Item(eColGrupoAcesso.eExcluir, e.RowIndex).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                        .Item(eColGrupoAcesso.eInserir, e.RowIndex).Value = .Item(e.ColumnIndex, e.RowIndex).Value
                    End With

            End Select


        Catch ex As Exception
            MsgBox("Erro: " & ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

#End Region

    

End Class