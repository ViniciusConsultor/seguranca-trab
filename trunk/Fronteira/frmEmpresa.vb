Imports Persistencia
Imports System.IO

Public Class frmEmpresa

#Region " Variáveis "

    Private bResultado As Boolean
    Private sCaminhoLogomarca As String
    Private dsDocumentos As New DataSet

    Public Property Resultado() As Boolean
        Get
            Return Me.bResultado
        End Get
        Set(ByVal value As Boolean)
            Me.bResultado = value
        End Set
    End Property

    Private picByte() As Byte = Nothing

    Private objEmpresa As New Controle.ctrEmpresa
    Private objDocumento As New Controle.ctrDocumento

    Public iIDEmpresa As Integer

#End Region

#Region " Métodos "

    Private Sub formataGridDocumentos()

        Try
            With Me.dgvDocumentos

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .ScrollBars = ScrollBars.Vertical

                .Columns.Clear()

                Dim Col1 As New DataGridViewCheckBoxColumn
                Col1.HeaderText = ""
                Col1.Name = "Marcar"
                Col1.Width = 30
                Col1.Frozen = True
                Col1.ReadOnly = False
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn
                Col2.HeaderText = "IDDocumento"
                Col2.Width = 50
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.NotSortable
                Col2.Visible = False
                Col2.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Nome"
                Col3.Width = 250
                Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Descrição"
                Col4.Width = 350
                Col4.Frozen = True
                Col4.ReadOnly = True
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewTextBoxColumn()
                Col5.HeaderText = "Documento"
                Col5.Width = 150
                Col5.Frozen = True
                Col5.ReadOnly = True
                Col5.FillWeight = 100
                Col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col5.SortMode = DataGridViewColumnSortMode.Automatic
                Col5.Visible = False
                Col5.ValueType = System.Type.GetType("System.Byte()")
                .Columns.Add(Col5)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmEmpresa_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If eModoAtual = eModo.eAguardando Then
            Me.fraPrincipal.Enabled = False
            Me.fraConfiguracoes.Enabled = False
            Me.cmdAdicionarDocumentos.Enabled = False
            Me.cmdExcluirDocumento.Enabled = False
            Me.cmdSelecionarEmpresa.Enabled = True
        Else
            Me.fraPrincipal.Enabled = True
            Me.fraConfiguracoes.Enabled = True
            Me.cmdAdicionarDocumentos.Enabled = True
            Me.cmdSelecionarEmpresa.Enabled = False
            Me.cmdExcluirDocumento.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)
        End If

        Me.dgvDocumentos.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)
        Me.cmdSelecionarTodos.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)
        Me.cmdExportarSelecionados.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)

    End Sub

    Public Sub frmEmpresa_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados

        Dim dsEmpresa As New DataSet
        Dim bits As Byte() = {0}
        Dim memorybits As MemoryStream
        Dim bitmap As Bitmap

        Me.cboEstado.Items.AddRange(Globais.sEstados)

        Try
            If (iChave > 0) Then

                MyBase.chave = iChave

                dsEmpresa = Me.objEmpresa.selecionar(iChave)

                If dsEmpresa.Tables(0).Rows.Count > 0 Then
                    With dsEmpresa.Tables(0).Rows(0)
                        Me.iIDEmpresa = Conversao.ToInt32(.Item("IDEmpresa"))
                        Me.txtNome.Text = Conversao.ToString(.Item("NomeFantasia"))
                        Me.txtRazaoSocial.Text = Conversao.ToString(.Item("RazaoSocial"))
                        Me.txtCNPJ.Text = Conversao.ToString(.Item("CNPJ"))
                        Me.txtSigla.Text = Conversao.ToString(.Item("Sigla"))
                        Me.txtEmail.Text = Conversao.ToString(.Item("Email"))
                        Me.txtLogradouro.Text = Conversao.ToString(.Item("Rua"))
                        Me.txtNumero.Text = Conversao.nuloParaVazio(.Item("Numero"))
                        Me.txtBairro.Text = Conversao.ToString(.Item("Bairro"))
                        Me.txtCidade.Text = Conversao.ToString(.Item("Cidade"))
                        Me.txtCEP.Text = Conversao.ToString(.Item("CEP"))
                        Me.txtTelefone.Text = Conversao.ToString(.Item("Telefone"))
                        Me.txtFax.Text = Conversao.ToString(.Item("Fax"))
                        If Conversao.ToString(.Item("Estado")) <> String.Empty Then
                            Me.cboEstado.SelectedIndex = Conversao.ToInt32(.Item("Estado"))
                        End If
                        Me.txtDuracaoCheckList.Text = Conversao.ToInt32(.Item("DuracaoCheckList"))

                        If .Item("AlertaTreinamento") Is System.DBNull.Value Then
                            chkTreinamentos.Checked = False
                        Else
                            chkTreinamentos.Checked = True
                            txtAlertaTreinamento.Text = Conversao.nuloParaZero(.Item("AlertaTreinamento"))
                        End If

                        If .Item("AlertaEPI") Is System.DBNull.Value Then
                            chkEPI.Checked = False
                        Else
                            chkEPI.Checked = True
                            txtAlertaEPI.Text = Conversao.nuloParaZero(.Item("AlertaEPI"))
                        End If

                        If .Item("AlertaDocumento") Is System.DBNull.Value Then
                            chkDocumentos.Checked = False
                        Else
                            chkDocumentos.Checked = True
                            txtAlertaDocumento.Text = Conversao.nuloParaZero(.Item("AlertaDocumento"))
                        End If

                        If .Item("AlertaAuditoria") Is System.DBNull.Value Then
                            chkAuditoria.Checked = False
                        Else
                            chkAuditoria.Checked = True
                            txtAlertaAuditoria.Text = Conversao.nuloParaZero(.Item("AlertaAuditoria"))
                        End If

                        'Carrega a logomarca
                        If Not .Item("Logomarca") Is System.DBNull.Value Then
                            bits = CType(.Item("Logomarca"), Byte())
                            memorybits = New MemoryStream(bits)
                            bitmap = New Bitmap(memorybits)
                            Me.pbLogomarca.Image = bitmap
                            Me.pbLogomarca.SizeMode = PictureBoxSizeMode.StretchImage
                            Me.picByte = .Item("Logomarca")
                        Else
                            Me.gerarLogomarcaImagem(Globais.byLogomarcaPadrao)
                        End If

                        'Carrega o grid de documentos
                        Me.dsDocumentos = Me.objDocumento.selecionarDocumento(iChave, Globais.eTipoArquivo.Empresa)
                        Me.preencheGridDocumentos()

                    End With
                End If

            End If

        Catch ex As Exception
            Me.pbLogomarca.Image = Nothing
            Me.pbLogomarca.Refresh()
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmEmpresa_gravar(ByRef bCancel As Boolean) Handles Me.gravar

        Dim iAlertaTreinamento As Integer = -1
        Dim iAlertaEPI As Integer = -1
        Dim iAlertaDocumento As Integer = -1
        Dim iAlertaAuditoria As Integer = -1

        Dim bRetorno As Boolean

        Try
            bCancel = True

            If (chkTreinamentos.Checked) Then
                iAlertaTreinamento = Val(txtAlertaTreinamento.Text)
            End If

            If (chkEPI.Checked) Then
                iAlertaEPI = Val(txtAlertaEPI.Text)
            End If

            If (chkDocumentos.Checked) Then
                iAlertaDocumento = Val(txtAlertaDocumento.Text)
            End If

            If (chkAuditoria.Checked) Then
                iAlertaAuditoria = Val(txtAlertaAuditoria.Text)
            End If
            bRetorno = Me.objEmpresa.salvar(Me.iIDEmpresa, _
                                            Me.txtNome.Text, _
                                            Me.txtRazaoSocial.Text, _
                                            Me.txtSigla.Text, _
                                            Me.txtLogradouro.Text, _
                                            Conversao.ToInt32(Me.txtNumero.Text), _
                                            Me.txtBairro.Text, _
                                            Me.txtCidade.Text, _
                                            IIf(Me.cboEstado.SelectedIndex > -1, Me.cboEstado.SelectedIndex, -1), _
                                            Me.txtCEP.Text, _
                                            Me.txtCNPJ.Text, _
                                            Me.txtEmail.Text, _
                                            Me.txtTelefone.Text, _
                                            Me.txtFax.Text, _
                                            Me.picByte, _
                                            Me.dsDocumentos, _
                                            Conversao.ToInt32(Me.txtDuracaoCheckList.Text), _
                                            iAlertaTreinamento, _
                                            iAlertaEPI, _
                                            iAlertaDocumento, _
                                            iAlertaAuditoria)

            If Not bRetorno Then

                MyBase.Mensagens = Me.objEmpresa.retornaMensagensValidacao

            Else

                bCancel = False
                Me.iIDEmpresa = Me.objEmpresa.IDEmpresa
                MyBase.chave = Me.objEmpresa.IDEmpresa
                Me.bResultado = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmEmpresa_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try

            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objEmpresa.excluir(Me.iIDEmpresa) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados a empresa que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                    bCancel = True
                Else
                    Me.iIDEmpresa = 0
                End If
            Else
                MyBase.Mensagens = Me.objEmpresa.retornaMensagensValidacao
                bCancel = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmEmpresa_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case Controle.ctrEmpresa.eMensagens.NOME_FANTASIA_OBRIGATORIO
                    Me.epPadrao.SetError(Me.cmdSelecionarEmpresa, sMensagem)
                Case Controle.ctrEmpresa.eMensagens.RAZAO_SOCIAL_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtRazaoSocial, sMensagem)
                Case Controle.ctrEmpresa.eMensagens.SIGLA_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtSigla, sMensagem)
            End Select

        Next

    End Sub

    Private Sub frmEmpresa_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        Me.epPadrao.SetError(Me.cmdSelecionarEmpresa, String.Empty)
        Me.epPadrao.SetError(Me.txtRazaoSocial, String.Empty)
        Me.epPadrao.SetError(Me.txtSigla, String.Empty)
    End Sub

    Private Sub frmEmpresa_limpaCampo() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)
        Me.dsDocumentos = Nothing
        Me.dsDocumentos = Me.objDocumento.selecionarDocumento(0, Globais.eTipoArquivo.Empresa)
        Me.formataGridDocumentos()
    End Sub

    Private Sub frmEmpresa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtNome.Focus()
        Me.cmdExcluirDocumento.Enabled = False
        Me.dsDocumentos = Me.objDocumento.selecionarDocumento(0, Globais.eTipoArquivo.Empresa)
    End Sub

    Private Sub frmEmpresa_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        MyBase.chave = 0
        Me.iIDEmpresa = 0
        Me.gerarLogomarcaImagem(Globais.byLogomarcaPadrao)
    End Sub

    Private Sub frmEmpresa_alterar(ByRef bCancel As Boolean) Handles Me.alterar
        MyBase.modoAtual = eModo.eAlterando
    End Sub

    Private Sub frmEmpresa_sair() Handles Me.sair
        If Me.iIDEmpresa > 0 Then
            Me.bResultado = True
        Else
            Me.bResultado = False
        End If

    End Sub

    Private Sub cmdSelecionarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarEmpresa.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        Try
            sSql = Me.objEmpresa.sqlConsulta(0, Globais.iIDUsuario)

            With frmDialogo
                .Sql = sSql
                .Titulo = "Pesquisa de Empresas"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Conversao.ToString(.ID)
                        Me.iIDEmpresa = MyBase.chave
                        frmEmpresa_carregaDados(MyBase.chave)
                        MyBase.alteraModopadrao(eModo.eAguardando)
                        frmEmpresa_alteraModo(eModo.eAguardando)
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

    Private Sub cmdSelecionarLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarLogo.Click

        Dim fs As FileStream


        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog()
            openDlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png"

            Dim filter As String = openDlg.Filter
            openDlg.Title = "Selecionar logomarca da empresa"

            If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                Me.sCaminhoLogomarca = openDlg.FileName
                Me.pbLogomarca.Image = New System.Drawing.Bitmap(Me.sCaminhoLogomarca)
                Me.pbLogomarca.SizeMode = PictureBoxSizeMode.StretchImage

                fs = New FileStream(Me.sCaminhoLogomarca, FileMode.Open, FileAccess.Read)
                ReDim Me.picByte(fs.Length)
                fs.Read(picByte, 0, System.Convert.ToInt32(fs.Length))
                fs.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdLimparLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimparLogo.Click

        Me.gerarLogomarcaImagem(Globais.byLogomarcaPadrao)

    End Sub

    Private Sub gerarLogomarcaImagem(ByVal byImagem As Byte())

        Dim bits As Byte() = {0}
        Dim memorybits As MemoryStream
        Dim bitmap As Bitmap

        bits = CType(byImagem, Byte())
        memorybits = New MemoryStream(bits)
        bitmap = New Bitmap(memorybits)
        Me.pbLogomarca.Image = bitmap
        Me.pbLogomarca.SizeMode = PictureBoxSizeMode.StretchImage
        Me.picByte = byImagem

    End Sub

    Private Sub gerarArquivoBytesLogomarcaPadrao()

        Dim sArquivoConexao As StreamWriter

        sArquivoConexao = New IO.StreamWriter(Globais.LocalExecutavel & "\teste.DS", IO.FileMode.Create)

        For i As Integer = 0 To Me.picByte.Length - 1
            sArquivoConexao.Write("'" & Me.picByte(i) & "',")
        Next

        sArquivoConexao.Close()
    End Sub

#End Region

    Private Sub preencheGridDocumentos()

        Dim iLinha As Integer

        Try

            Me.formataGridDocumentos()

            If Me.dsDocumentos.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvDocumentos
                    .Rows.Clear()
                    .RowCount = Me.dsDocumentos.Tables(0).Rows.Count

                    For Each drDados As DataRow In Me.dsDocumentos.Tables(0).Rows

                        .Item(Controle.ctrEmpresa.eGridEmpresa.eMarcar, iLinha).Value = False
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eIdDocumento, iLinha).Value = drDados.Item("IDDocumento")
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eNome, iLinha).Value = drDados.Item("NomeArquivo")
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eDescricao, iLinha).Value = drDados.Item("Descricao")
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eDocumento, iLinha).Value = drDados.Item("Arquivo")

                        iLinha += 1
                    Next

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdAdicionarDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarDocumentos.Click

        Dim frm As New frmDocumento

        frm.Documentos = Me.dsDocumentos
        frm.modoInsercao = True
        frm.ShowDialog()

        Me.dsDocumentos = frm.Documentos
        Me.preencheGridDocumentos()
        Me.cmdExcluirDocumento.Enabled = Me.dsDocumentos.Tables(0).Rows.Count > 0

    End Sub

    Private Sub cmdExcluirDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirDocumento.Click

        For Each SelectedRow As DataGridViewRow In Me.dgvDocumentos.Rows
            If Conversao.ToBoolean(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eMarcar).Value) = True Then
                Me.dsDocumentos.Tables(0).Rows(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eMarcar).RowIndex).Delete()
            End If
        Next

        Me.dsDocumentos.AcceptChanges()
        Me.preencheGridDocumentos()
    End Sub

    Private Sub dgvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDocumentos.DoubleClick

        Dim frm As New frmDocumento

        frm.Index = Me.dgvDocumentos.CurrentRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eIdDocumento.GetHashCode).RowIndex
        frm.Documentos = Me.dsDocumentos
        frm.modoInsercao = False
        frm.ShowDialog()

        Me.dsDocumentos = frm.Documentos
        Me.preencheGridDocumentos()

    End Sub

    Private Sub selecaoGrid(ByVal bMarcar As Boolean)

        For iContador As Integer = 0 To Me.dgvDocumentos.Rows.Count - 1
            Me.dgvDocumentos.Item(Controle.ctrEmpresa.eGridEmpresa.eMarcar, iContador).Value = bMarcar
        Next

    End Sub

    Private Sub cmdSelecionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos.Click

        If Me.cmdSelecionarTodos.Text = "Selecionar todos" Then
            Me.selecaoGrid(True)
            Me.cmdSelecionarTodos.Text = "Desmarcar todos"
        Else
            Me.selecaoGrid(False)
            Me.cmdSelecionarTodos.Text = "Selecionar todos"
        End If

    End Sub

    Private Sub cmdExportarSelecionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarSelecionados.Click

        Dim fs As FileStream
        Dim sCaminhoSelecionado As String
        Dim sNomeArquivo As String
        Dim bits As Byte() = {0}
        Dim memorybits As MemoryStream

        Try
            Dim openDlg As FolderBrowserDialog = New FolderBrowserDialog
            openDlg.ShowNewFolderButton = True

            If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                sCaminhoSelecionado = openDlg.SelectedPath

                For Each SelectedRow As DataGridViewRow In Me.dgvDocumentos.Rows
                    If Conversao.ToBoolean(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eMarcar).Value) = True Then

                        bits = CType(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eDocumento).Value, Byte())
                        sNomeArquivo = SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eNome).Value
                        memorybits = New MemoryStream(bits)

                        fs = New FileStream(sCaminhoSelecionado & "\" & sNomeArquivo, FileMode.Create, FileAccess.Write)
                        fs.Write(bits, 0, bits.Length)
                        fs.Close()

                    End If
                Next

                MsgBox("Os documentos foram exportados com sucesso.", MsgBoxStyle.Information, Me.Text)

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdAssocNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssociarNR.Click
        Dim frmAssocNR As New frmAssocNR

        frmAssocNR.Carregar_Tela(Me.modoAtual = eModo.eAguardando)

    End Sub

    Private Sub chkTreinamentos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTreinamentos.CheckedChanged
        txtAlertaTreinamento.Enabled = chkTreinamentos.Checked
        lblMesesTreinamento.Enabled = chkTreinamentos.Checked

        If (chkTreinamentos.Checked = False) Then
            txtAlertaTreinamento.Text = ""
        End If
    End Sub

    Private Sub chkEPI_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEPI.CheckedChanged
        txtAlertaEPI.Enabled = chkEPI.Checked
        lblMesesEPI.Enabled = chkEPI.Checked

        If (chkEPI.Checked = False) Then
            txtAlertaEPI.Text = ""
        End If
    End Sub

    Private Sub chkDocumentos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDocumentos.CheckedChanged
        txtAlertaDocumento.Enabled = chkDocumentos.Checked
        lblMesesDocumento.Enabled = chkDocumentos.Checked

        If (chkDocumentos.Checked = False) Then
            txtAlertaDocumento.Text = ""
        End If
    End Sub

    Private Sub chkAuditoria_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAuditoria.CheckedChanged
        txtAlertaAuditoria.Enabled = chkAuditoria.Checked
        lblMesesAuditoria.Enabled = chkAuditoria.Checked
        If (chkAuditoria.Checked = False) Then
            txtAlertaAuditoria.Text = ""
        End If
    End Sub

End Class