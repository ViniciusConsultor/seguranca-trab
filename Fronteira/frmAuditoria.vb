Imports Controle
Imports Persistencia
Imports System.IO
Public Class frmAuditoria

#Region "Enumerações"

    Private Enum eColunasGrid
        Artigo = 0
        IDItem = 1
        Questao = 2
        Situacao = 3
        Justificativa = 4
        Auditoria = 5
        Argumento = 6
        Documento = 7
        ExcluirDocumento = 8
        Evidencia = 9
        IDItemCheckList = 10
        DescricaoDocumento = 11
        Arquivo = 12
        IDDocumento = 13
    End Enum

#End Region

#Region "Variáveis"

    Private iPrvIDAuditoria As Integer
    Private iPrvIDCheckList As Integer
    Private iPrvStatusAuditoria As Integer

    Private objAcesso As New perAcessoBD
    Private objAuditoria As New ctrAuditoria
    Private objCheckList As New ctrCheckList
    Private objEmpresa As New ctrEmpresa

#End Region

#Region "Funções"

    Private Sub Configurar_Grid()

        Try

            With Me.dgvAuditoria
                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = True
                .RowHeadersVisible = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Clear()

                Dim Col_Artigo As New DataGridViewTextBoxColumn()
                With Col_Artigo
                    .HeaderText = "Artigo"
                    .Width = 40
                    .ReadOnly = True
                    .FillWeight = 55
                    .Visible = True
                    .ValueType = System.Type.GetType("System.string")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_Artigo)

                Dim Col_IDItem As New DataGridViewTextBoxColumn()
                With Col_IDItem
                    .HeaderText = "IDItem"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Integer")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                End With
                .Columns.Add(Col_IDItem)

                Dim Col_Questao As New DataGridViewTextBoxColumn()
                With Col_Questao
                    .HeaderText = "Questão"
                    .Width = 180
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Questao)

                Dim Col_SitCheckList As New DataGridViewTextBoxColumn
                With Col_SitCheckList
                    .HeaderText = "CL"
                    .Width = 30
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_SitCheckList)

                Dim Col_Justificativa As New DataGridViewTextBoxColumn()
                With Col_Justificativa
                    .HeaderText = "Justificativa"
                    .Width = 150
                    .Frozen = False
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Justificativa)

                Dim Col_Auditoria As New DataGridViewComboBoxColumn()
                With Col_Auditoria
                    .HeaderText = "Auditoria"
                    .Items.Add("Não Verificado")
                    .Items.Add("Ok")
                    .Items.Add("Não Ok")
                    .Width = 95
                    .Frozen = False
                    .ReadOnly = False
                    .Visible = True
                End With
                .Columns.Add(Col_Auditoria)

                Dim Col_Argumento As New DataGridViewTextBoxColumn()
                With Col_Argumento
                    .HeaderText = "Argumento"
                    .Width = 165
                    .Frozen = False
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Argumento)

                Dim icoAdicionar As New Icon(Me.GetType(), "Adicionar.ico")
                Dim Col_Documento As New DataGridViewImageColumn()
                With Col_Documento
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
                .Columns.Add(Col_Documento)

                Dim icoExcluir As New Icon(Me.GetType(), "Excluir2.ico")
                Dim Col_ExcluirDocumento As New DataGridViewImageColumn
                With Col_ExcluirDocumento
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
                .Columns.Add(Col_ExcluirDocumento)

                Dim Col_Evidencia As New DataGridViewLinkColumn
                With Col_Evidencia
                    .HeaderText = "Evidência"
                    .Width = 140
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Evidencia)

                Dim Col_IDItemCheckList As New DataGridViewTextBoxColumn()
                With Col_IDItemCheckList
                    .HeaderText = "IDArquivo"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_IDItemCheckList)

                Dim Col_DescricaoDocumento As New DataGridViewTextBoxColumn()
                With Col_DescricaoDocumento
                    .HeaderText = "DescricaoDocumento"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_DescricaoDocumento)

                Dim Col_Arquivo As New DataGridViewTextBoxColumn
                With Col_Arquivo
                    .HeaderText = "Arquivo"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Byte[]")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_Arquivo)
                .Refresh()

                Dim Col_IDDocumento As New DataGridViewTextBoxColumn()
                With Col_IDDocumento
                    .HeaderText = "IDDocumento"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_IDDocumento)


                .Refresh()

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub Preencher_Auditoria()
        Dim dtbDados As New DataTable
        Dim iLinha As Integer = 0
        Dim btStatus As Integer = 0

        Try
            dtbDados = objAuditoria.Retornar_Itens_Auditoria(Me.iPrvIDCheckList, Me.iPrvIDAuditoria)

            With dgvAuditoria
                .Rows.Clear()
                If (dtbDados.Rows.Count > 0) Then
                    .RowCount = dtbDados.Rows.Count

                    For Each drDados As DataRow In dtbDados.Rows

                        .Item(eColunasGrid.Artigo, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Artigo"))
                        .Item(eColunasGrid.IDItem, iLinha).Value = Conversao.nuloParaZero(drDados.Item("IDItem"))
                        .Item(eColunasGrid.Questao, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Questao"))
                        .Item(eColunasGrid.Justificativa, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Justificativa"))

                        btStatus = Conversao.nuloParaZero(drDados.Item("StatusItem"))

                        Select Case btStatus
                            Case Persistencia.perCheckList.eSituacaoItem.SemResposta
                                .Item(eColunasGrid.Situacao, iLinha).Value = "Não Verificado"
                            Case Persistencia.perCheckList.eSituacaoItem.Ok
                                .Item(eColunasGrid.Situacao, iLinha).Value = "Ok"
                            Case Persistencia.perCheckList.eSituacaoItem.NaoOk
                                .Item(eColunasGrid.Situacao, iLinha).Value = "Não Ok"
                        End Select

                        'Itens editáveis
                        btStatus = Conversao.nuloParaZero(drDados.Item("Status_Item"))
                        Select Case btStatus
                            Case Persistencia.perAuditoria.eSituacaoItem.SemResposta
                                .Item(eColunasGrid.Auditoria, iLinha).Value = "Não Verificado"
                            Case Persistencia.perAuditoria.eSituacaoItem.Ok
                                .Item(eColunasGrid.Auditoria, iLinha).Value = "Ok"
                            Case Persistencia.perAuditoria.eSituacaoItem.NaoOk
                                .Item(eColunasGrid.Auditoria, iLinha).Value = "Não Ok"
                        End Select

                        .Item(eColunasGrid.Argumento, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Auditoria"))
                        .Item(eColunasGrid.Argumento, iLinha).ReadOnly = (btStatus = 0)

                        .Item(eColunasGrid.Documento, iLinha).ReadOnly = (btStatus = 0)

                        .Item(eColunasGrid.Evidencia, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("NomeArquivo"))
                        .Item(eColunasGrid.IDItemCheckList, iLinha).Value = Conversao.ToInt32(drDados.Item("IDArquivo"))
                        .Item(eColunasGrid.DescricaoDocumento, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("DescricaoArquivo"))

                        If Not drDados.Item("Arquivo") Is DBNull.Value Then
                            .Item(eColunasGrid.Arquivo, iLinha).Value = drDados.Item("Arquivo")
                        End If

                        .Item(eColunasGrid.IDDocumento, iLinha).Value = Conversao.ToInt32(drDados.Item("IDDocumento"))

                        iLinha += 1
                    Next

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Function Validar_Conclusao_Auditoria() As Boolean
        Dim bResultado As Boolean = True

        For cont As Integer = 0 To dgvAuditoria.RowCount - 1

            With dgvAuditoria

                If (.Item(eColunasGrid.Auditoria, cont).Value = "Não Verificado") Then
                    bResultado = False
                End If

            End With

        Next

        Return bResultado

    End Function

#End Region

#Region "Eventos"

    Private Sub frmAuditoria_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If eModoAtual = eModo.eAguardando Then
            cmdPesquisaAuditoria.Enabled = True
            cmdPesquisaCheckList.Enabled = False
            txtDataAuditoria.Enabled = False
            dgvAuditoria.ReadOnly = True
        Else
            cmdPesquisaAuditoria.Enabled = False
            cmdPesquisaCheckList.Enabled = (Me.iPrvIDAuditoria = 0)
            txtDataAuditoria.Enabled = (Me.iPrvIDAuditoria = 0)
            dgvAuditoria.ReadOnly = False
        End If

    End Sub

    Private Sub frmAuditoria_alterar(ByRef bCancel As Boolean) Handles Me.alterar

        If (Me.iPrvStatusAuditoria = perAuditoria.eStatusAuditoria.Concluido) Then
            MsgBox("Auditoria concluída. Alteração cancelada.")
            bCancel = True
            MyBase.modoAtual = eModo.eAguardando
            alteraModopadrao(eModo.eAguardando)
        End If

    End Sub

    Private Sub frmAuditoria_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados

        Dim dtbAuditoria As New DataTable

        Try

            If (Me.iPrvIDAuditoria > 0) Then

                dtbAuditoria = objAuditoria.Retornar_Dados_Auditoria(iPrvIDAuditoria)

                If (dtbAuditoria.Rows.Count > 0) Then
                    With dtbAuditoria.Rows(0)
                        Me.iPrvIDAuditoria = Conversao.nuloParaZero(.Item("IDAuditoria"))
                        txtIDAuditoria.Text = Me.iPrvIDAuditoria
                        Me.iPrvIDCheckList = Conversao.nuloParaZero(.Item("IDCheckList"))
                        lblDataCheck.Text = Conversao.nuloParaData(.Item("DataCheck"))
                        txtNR.Text = Conversao.nuloParaZero(.Item("IDNR"))
                        txtDescNR.Text = Conversao.nuloParaVazio(.Item("Descricao"))
                        txtDataAuditoria.Text = Conversao.nuloParaData(.Item("dataAuditoria"))

                        iPrvStatusAuditoria = Conversao.nuloParaZero(.Item("Status"))

                        Select Case iPrvStatusAuditoria
                            Case Persistencia.perAuditoria.eStatusAuditoria.Cadastrado
                                lblStatusCheckList.Text = "Cadastrado"
                                lblStatusCheckList.ForeColor = Color.DarkBlue
                            Case Persistencia.perAuditoria.eStatusAuditoria.Concluido
                                lblStatusCheckList.Text = "Concluído"
                                lblStatusCheckList.ForeColor = Color.DarkRed
                        End Select

                        Preencher_Auditoria()
                    End With
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAuditoria_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try

            bCancel = True

            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Me.objAuditoria.Excluir_Auditoria(iPrvIDAuditoria) Then
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvIDCheckList = 0
                    Me.iPrvIDAuditoria = 0
                    Me.iPrvStatusAuditoria = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAuditoria_gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim dsAuditoria As New DataSet
        Dim bRetorno As Boolean
        Dim iTodasChecadas As Integer = perCheckList.eStatusCheckList.Cadastrado

        Try
            bCancel = True
            dsAuditoria = Conversao.converteGridParaDataset(dgvAuditoria)

            If (Me.Validar_Conclusao_Auditoria) Then
                If (MsgBox("Todas os artigos desta auditoria foram checados. Deseja marcar a auditoria como concluída?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                    iPrvStatusAuditoria = perAuditoria.eStatusAuditoria.Concluido
                End If
            End If

            bRetorno = objAuditoria.Salvar_Auditoria(Me.iPrvIDAuditoria, iPrvIDCheckList, txtDataAuditoria.Text, _
                                                     iPrvStatusAuditoria, dsAuditoria, lblDataCheck.Text)

            If (bRetorno) Then
                bCancel = False
                Me.iPrvIDAuditoria = Me.objAuditoria.IDAuditoria
                MyBase.chave = Me.iPrvIDCheckList
            Else
                MyBase.Mensagens = objCheckList.retornaMensagensValidacao
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAuditoria_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        iPrvIDCheckList = 0
        iPrvIDAuditoria = 0
        Me.iPrvIDAuditoria = 0
    End Sub

    Private Sub frmAuditoria_limpaCampo() Handles Me.limpaCampo
        txtNR.Text = ""
        txtDescNR.Text = ""
        txtIDAuditoria.Text = ""
        txtDataAuditoria.Text = objAcesso.Data_Servidor
        lblDataCheck.Text = "__/__/____"
        dgvAuditoria.Rows.Clear()
    End Sub

    Private Sub frmAuditoria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Configurar_Grid()
    End Sub

    Private Sub dgvAuditoria_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAuditoria.CellClick

        Try
            Select Case e.ColumnIndex

                Case eColunasGrid.Documento

                    Dim frm As New frmDocumento

                    frm.FormCheckList = True

                    frm.DescricaoArquivo = Me.dgvAuditoria.Item(eColunasGrid.DescricaoDocumento, e.RowIndex).Value
                    frm.NomeArquivo = Me.dgvAuditoria.Item(eColunasGrid.Evidencia, e.RowIndex).Value

                    frm.ShowDialog()

                    If frm.OK Then
                        Me.dgvAuditoria.Item(eColunasGrid.Evidencia, e.RowIndex).Value = frm.NomeArquivo
                        Me.dgvAuditoria.Item(eColunasGrid.DescricaoDocumento, e.RowIndex).Value = frm.DescricaoArquivo
                        Me.dgvAuditoria.Item(eColunasGrid.Arquivo, e.RowIndex).Value = frm.Arquivo
                    End If

                Case eColunasGrid.Evidencia

                    If Not String.IsNullOrEmpty(Me.dgvAuditoria.Item(eColunasGrid.Evidencia, e.RowIndex).Value) Then
                        Me.exportarDocumentos(Me.dgvAuditoria.Item(eColunasGrid.Arquivo, e.RowIndex).Value, _
                                              Me.dgvAuditoria.Item(eColunasGrid.Evidencia, e.RowIndex).Value)

                    End If

                Case eColunasGrid.ExcluirDocumento

                    Me.dgvAuditoria.Item(eColunasGrid.Evidencia, e.RowIndex).Value = String.Empty
                    Me.dgvAuditoria.Item(eColunasGrid.DescricaoDocumento, e.RowIndex).Value = String.Empty

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try


    End Sub

    Private Sub dgvAuditoria_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAuditoria.CellValueChanged

        Dim iStatus As Integer

        If e.ColumnIndex = eColunasGrid.Auditoria Then

            With dgvAuditoria
                If (.Item(eColunasGrid.Auditoria, e.RowIndex).Value Is Nothing) Then
                    iStatus = 0
                    .Item(eColunasGrid.Argumento, e.RowIndex).Value = Nothing
                Else
                    iStatus = 1
                End If

                .Item(eColunasGrid.Argumento, e.RowIndex).ReadOnly = (iStatus = 0)

            End With
        End If

    End Sub

    Private Sub cmdPesquisaCheckList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisaCheckList.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa
        Dim dtbCheckList As New DataTable

        Try
            sSql = Me.objCheckList.sqlConsulta_Concluidos()

            With frmDialogo
                .Sql = sSql
                .Titulo = "Check-List - Auditoria"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Conversao.nuloParaZero(.ID)
                        Me.iPrvIDCheckList = CInt(MyBase.chave)

                        dtbCheckList = objCheckList.Retornar_Dados_CheckList(iPrvIDCheckList)

                        If (dtbCheckList.Rows.Count > 0) Then
                            With dtbCheckList.Rows(0)
                                lblDataCheck.Text = Persistencia.Conversao.nuloParaData(.Item("Data")).ToString("dd/MM/yyyy")
                                txtNR.Text = Persistencia.Conversao.nuloParaZero(.Item("IDNR"))
                                txtDescNR.Text = Persistencia.Conversao.nuloParaVazio(.Item("DescricaoNR"))

                                Preencher_Auditoria()
                            End With

                        End If

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

    Private Sub frmAuditoria_setarProvedorDeErros() Handles Me.setarProvedorDeErros
        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case ctrCheckList.eMensagens.ITENS_EM_FALTA
                    Me.epPadrao.SetError(Me.dgvAuditoria, sMensagem)
            End Select

        Next
    End Sub

#End Region

    Private Sub cmdPesquisaAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisaAuditoria.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa
        Dim dtbCheckList As New DataTable

        Try
            sSql = Me.objAuditoria.sqlConsulta

            With frmDialogo
                .Sql = sSql
                .Titulo = "Auditoria"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Conversao.nuloParaZero(.ID)
                        Me.iPrvIDAuditoria = CInt(MyBase.chave)
                        frmAuditoria_carregaDados(iPrvIDAuditoria)
                        Call Preencher_Auditoria()

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

    Private Sub exportarDocumentos(ByVal Arquivo As Byte(),
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

End Class