Imports Controle
Imports Persistencia
Imports System.IO

Public Class frmCheckList

#Region "Enumerações"

    Private Enum eColunasGrid
        IDNR = 0
        Artigo = 1
        Penalidade = 2
        IDQuestao = 3
        Questao = 4
        Situacao = 5
        Justificativa = 6
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

    Private iPrvIDNR As Integer
    Private iPrvIDCheckList As Integer
    Private iPrvStatusCheck As Integer

    Private objNR As New ctrNR
    Private objAcesso As New perAcessoBD
    Private objCheckList As New ctrCheckList
    Private objEmpresa As New ctrEmpresa

#End Region

#Region "Funções"

    Private Sub Configurar_Grid()

        Try

            With Me.dgvCheckList
                .DataSource = Nothing
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = True
                .RowHeadersVisible = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True

                .Columns.Clear()

                Dim Col_NR As New DataGridViewTextBoxColumn()
                With Col_NR
                    .HeaderText = "NR"
                    .Width = 30
                    .ReadOnly = True
                    .FillWeight = 30
                    .Visible = True
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_NR)

                Dim Col_Artigo As New DataGridViewTextBoxColumn()
                With Col_Artigo
                    .HeaderText = "Artigo"
                    .Width = 55
                    .ReadOnly = True
                    .FillWeight = 55
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_Artigo)

                Dim Col_Penalidade As New DataGridViewTextBoxColumn()
                With Col_Penalidade
                    .HeaderText = "Penalidade"
                    .ReadOnly = True
                    .Visible = True
                    .FillWeight = 70
                    .Width = 70
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                .Columns.Add(Col_Penalidade)

                Dim Col_IDQuestao As New DataGridViewTextBoxColumn()
                With Col_IDQuestao
                    .HeaderText = "IDQuestao"
                    .ReadOnly = True
                    .Visible = False
                    .ValueType = System.Type.GetType("System.Int32")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.NullValue = 0
                End With
                .Columns.Add(Col_IDQuestao)

                Dim Col_Questao As New DataGridViewTextBoxColumn()
                With Col_Questao
                    .HeaderText = "Questão"
                    .Width = 200
                    .ReadOnly = True
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Questao)

                Dim Col_Situacao As New DataGridViewComboBoxColumn()
                With Col_Situacao
                    .HeaderText = "Situação"
                    .Items.Add("Não Verificado")
                    .Items.Add("Ok")
                    .Items.Add("Não Ok")
                    .Width = 90
                    .Frozen = False
                    .ReadOnly = False
                    .FillWeight = 90
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                End With
                .Columns.Add(Col_Situacao)

                Dim Col_Justificativa As New DataGridViewTextBoxColumn()
                With Col_Justificativa
                    .HeaderText = "Justificativa"
                    .Width = 250
                    .Frozen = False
                    .ReadOnly = False
                    .Visible = True
                    .ValueType = System.Type.GetType("System.String")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns.Add(Col_Justificativa)

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
                    .Width = 160
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

    Private Sub Preencher_CheckList()
        Dim dtbDados As New DataTable
        Dim iLinha As Integer = 0
        Dim btStatus As Integer = 0

        Try
            If (iPrvIDNR > 0 Or iPrvIDCheckList > 0) Then
                dtbDados = objNR.Retornar_CheckList(Globais.iIDEmpresa, Me.iPrvIDCheckList, Me.iPrvIDNR)

                With dgvCheckList
                    .Rows.Clear()
                    If (dtbDados.Rows.Count > 0) Then
                        .RowCount = dtbDados.Rows.Count
                        For Each drDados As DataRow In dtbDados.Rows
                            .Item(eColunasGrid.IDNR, iLinha).Value = Conversao.nuloParaZero(drDados.Item("IDNR"))
                            .Item(eColunasGrid.Artigo, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Artigo"))
                            .Item(eColunasGrid.Penalidade, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Penalidade"))
                            .Item(eColunasGrid.IDQuestao, iLinha).Value = Conversao.ToInt32(drDados.Item("IDQuestao"))
                            .Item(eColunasGrid.Questao, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Questao"))

                            'Itens editáveis
                            btStatus = Conversao.nuloParaZero(drDados.Item("StatusItem"))

                            Select Case btStatus
                                Case Persistencia.perCheckList.eSituacaoItem.SemResposta
                                    .Item(eColunasGrid.Situacao, iLinha).Value = "Não Verificado"
                                Case Persistencia.perCheckList.eSituacaoItem.Ok
                                    .Item(eColunasGrid.Situacao, iLinha).Value = "Ok"
                                Case Persistencia.perCheckList.eSituacaoItem.NaoOk
                                    .Item(eColunasGrid.Situacao, iLinha).Value = "Não Ok"
                            End Select

                            .Item(eColunasGrid.Justificativa, iLinha).Value = Conversao.nuloParaVazio(drDados.Item("Justificativa"))
                            .Item(eColunasGrid.Justificativa, iLinha).ReadOnly = (btStatus = 0)

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
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try


    End Sub

    Private Function Validar_Conclusao_CheckList() As Boolean
        Dim bResultado As Boolean = True

        For cont As Integer = 0 To dgvCheckList.RowCount - 1

            With dgvCheckList

                If (.Item(eColunasGrid.Situacao, cont).Value = "Não Verificado") Then
                    bResultado = False
                End If

            End With

        Next

        Return bResultado

    End Function

#End Region

#Region "Eventos"

    Private Sub frmCheckList_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If eModoAtual = eModo.eAguardando Then
            cmdPesquisaCheckList.Enabled = True
            cmdPesquisarNR.Enabled = False
            txtDtInicio.Enabled = False
            fraPlanilha.Enabled = False

        Else
            cmdPesquisaCheckList.Enabled = False
            txtDtInicio.Enabled = (Me.iPrvIDCheckList = 0)
            cmdPesquisarNR.Enabled = (Me.iPrvIDCheckList = 0)
            fraPlanilha.Enabled = True
        End If

    End Sub

    Private Sub frmCheckList_alterar(ByRef bCancel As Boolean) Handles Me.alterar

        If (Me.iPrvStatusCheck = perCheckList.eStatusCheckList.Concluido) Then
            MsgBox("Check-list concluído. Alteração cancelada.")
            bCancel = True
            MyBase.modoAtual = eModo.eAguardando
            alteraModopadrao(eModo.eAguardando)
        End If

    End Sub

    Private Sub frmCheckList_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados
        Dim dtbCheckList As New DataTable

        Try
            If (Me.iPrvIDCheckList > 0) Then

                dtbCheckList = objCheckList.Retornar_Dados_CheckList(Me.iPrvIDCheckList)

                If (dtbCheckList.Rows.Count > 0) Then
                    With dtbCheckList.Rows(0)
                        Me.iPrvIDNR = Conversao.nuloParaZero(.Item("IDNr"))
                        txtNR.Text = Me.iPrvIDNR
                        txtDescricao.Text = Conversao.nuloParaVazio(.Item("DescricaoNr"))
                        txtDtInicio.Text = Conversao.nuloParaData(.Item("data"))

                        Me.iPrvStatusCheck = Conversao.nuloParaZero(.Item("StatusCheckList"))

                        Select Case iPrvStatusCheck
                            Case Persistencia.perCheckList.eStatusCheckList.Cadastrado
                                lblStatusCheckList.Text = "Cadastrado"
                                lblStatusCheckList.ForeColor = Color.DarkBlue
                            Case Persistencia.perCheckList.eStatusCheckList.Concluido
                                lblStatusCheckList.Text = "Concluído"
                                lblStatusCheckList.ForeColor = Color.DarkRed
                        End Select

                        Preencher_CheckList()
                    End With
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCheckList_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Dim sMensagem As String = String.Empty

        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then

                If Not Me.objCheckList.Excluir_CheckList(Me.iPrvIDCheckList,
                                                         iPrvStatusCheck) Then
                    MyBase.Mensagens = objCheckList.retornaMensagensValidacao

                    For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1
                        sMensagem &= MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens) & Environment.NewLine
                    Next

                    MessageBox.Show(sMensagem, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvIDCheckList = 0
                    Me.iPrvIDNR = 0
                    Me.iPrvStatusCheck = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCheckList_gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim dsCheckList As New DataSet
        Dim bRetorno As Boolean
        Dim iTodasChecadas As Integer = perCheckList.eStatusCheckList.Cadastrado

        Try
            bCancel = True
            dsCheckList = Conversao.converteGridParaDataset(Me.dgvCheckList)

            If (Me.Validar_Conclusao_CheckList) Then
                If (MsgBox("Todas os artigos desta NR foram checados. Deseja marcar check-list como concluído?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                    iTodasChecadas = perCheckList.eStatusCheckList.Concluido
                End If
            End If

            bRetorno = objCheckList.Salvar(iPrvIDCheckList, iPrvIDNR, Globais.iIDEmpresa, txtDtInicio.Text, dsCheckList, iTodasChecadas)

            If (bRetorno) Then
                bCancel = False
                Me.iPrvIDCheckList = Me.objCheckList.IDCheckList
                MyBase.chave = Me.iPrvIDCheckList
            Else
                MyBase.Mensagens = objCheckList.retornaMensagensValidacao
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCheckList_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        iPrvIDCheckList = 0
        iPrvStatusCheck = 0
        Me.Preencher_CheckList()
    End Sub

    Private Sub frmCheckList_limpaCampo() Handles Me.limpaCampo

        txtNR.Text = ""
        txtDescricao.Text = ""
        txtDtInicio.Text = objAcesso.Data_Servidor
        dgvCheckList.Rows.Clear()

    End Sub

    Private Sub frmCheckList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Configurar_Grid()
    End Sub

    Private Sub dgvCheckList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCheckList.CellClick

        Select Case e.ColumnIndex

            Case eColunasGrid.Documento
                Dim frm As New frmDocumento

                frm.FormCheckList = True

                frm.DescricaoArquivo = Me.dgvCheckList.Item(eColunasGrid.DescricaoDocumento, e.RowIndex).Value
                frm.NomeArquivo = Me.dgvCheckList.Item(eColunasGrid.Evidencia, e.RowIndex).Value

                frm.ShowDialog()

                If frm.OK Then
                    Me.dgvCheckList.Item(eColunasGrid.Evidencia, e.RowIndex).Value = frm.NomeArquivo
                    Me.dgvCheckList.Item(eColunasGrid.DescricaoDocumento, e.RowIndex).Value = frm.DescricaoArquivo
                    Me.dgvCheckList.Item(eColunasGrid.Arquivo, e.RowIndex).Value = frm.Arquivo
                End If

            Case eColunasGrid.Evidencia
                If Not String.IsNullOrEmpty(Me.dgvCheckList.Item(eColunasGrid.Evidencia, e.RowIndex).Value) Then
                    Me.exportarDocumentos(Me.dgvCheckList.Item(eColunasGrid.Arquivo, e.RowIndex).Value, _
                                      Me.dgvCheckList.Item(eColunasGrid.Evidencia, e.RowIndex).Value)

                End If

            Case eColunasGrid.ExcluirDocumento
                Me.dgvCheckList.Item(eColunasGrid.Evidencia, e.RowIndex).Value = String.Empty
                Me.dgvCheckList.Item(eColunasGrid.DescricaoDocumento, e.RowIndex).Value = String.Empty

        End Select
  

    End Sub

    Private Sub cmdPesquisarNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisarNR.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa
        Dim dtData As Date

        dtData = CDate(txtDtInicio.Text)
        sSql = Me.objNR.sqlNRCheckList(Globais.iIDEmpresa, dtData)

        With frmDialogo
            .Sql = sSql
            .Titulo = "Check-List NR"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iPrvIDNR = Conversao.nuloParaZero(.ID)
                    Me.txtNR.Text = Me.iPrvIDNR
                    Me.txtDescricao.Text = objNR.Retornar_Descricao_NR(iPrvIDNR)
                End If

                Me.Preencher_CheckList()
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub dgvCheckList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCheckList.CellValueChanged
        Dim iStatus As Integer

        Try
            If (e.ColumnIndex = eColunasGrid.Situacao) Then
                With dgvCheckList
                    If (.Item(eColunasGrid.Situacao, e.RowIndex).Value Is Nothing) Then
                        iStatus = 0
                    Else
                        iStatus = 1
                    End If

                    .Item(eColunasGrid.Justificativa, e.RowIndex).ReadOnly = (iStatus = 0)
                    .Item(eColunasGrid.Documento, e.RowIndex).ReadOnly = (iStatus = 0)

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmdPesquisaCheckList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisaCheckList.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa
        Try
            sSql = Me.objCheckList.sqlConsulta()

            With frmDialogo
                .Sql = sSql
                .Titulo = "Check-List"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Conversao.nuloParaZero(.ID)
                        Me.iPrvIDCheckList = CInt(MyBase.chave)

                        frmCheckList_carregaDados(Me.iPrvIDCheckList)

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

    Private Sub frmCheckList_setarProvedorDeErros() Handles Me.setarProvedorDeErros
        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case ctrCheckList.eMensagens.ITENS_EM_FALTA
                    Me.epPadrao.SetError(Me.dgvCheckList, sMensagem)
            End Select

        Next
    End Sub


#End Region

End Class