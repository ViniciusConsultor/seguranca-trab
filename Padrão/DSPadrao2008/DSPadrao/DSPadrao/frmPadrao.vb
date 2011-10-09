Public Class frmPadrao

#Region " Propriedades "

    Property estadoAtual() As eEstado
        Get
            Return iEstado
        End Get
        Set(ByVal Value As eEstado)
            iEstado = Value
        End Set
    End Property

    Public Property chave() As Integer
        Get
            Return iChave
        End Get
        Set(ByVal Value As Integer)
            iChave = Value
        End Set
    End Property

    Property Mensagens() As ArrayList
        Get
            Return alColecaoMensagem
        End Get
        Set(ByVal value As ArrayList)
            alColecaoMensagem = value
        End Set
    End Property

    Property menuChamador() As String
        Get
            Return sMenu
        End Get
        Set(ByVal Value As String)
            sMenu = Value
        End Set
    End Property

    Property idGrupoAcesso() As Integer
        Get
            Return iIDGrupoAcesso
        End Get
        Set(ByVal Value As Integer)
            iIDGrupoAcesso = Value
        End Set
    End Property

    Property acessoInserir() As Boolean
        Get
            Return bInserir
        End Get
        Set(ByVal Value As Boolean)
            bInserir = Value
        End Set
    End Property

    Property acessoExcluir() As Boolean
        Get
            Return bExcluir
        End Get
        Set(ByVal Value As Boolean)
            bExcluir = Value
        End Set
    End Property

    Property acessoAlterar() As Boolean
        Get
            Return bAlterar
        End Get
        Set(ByVal Value As Boolean)
            bAlterar = Value
        End Set
    End Property

    Property acessoConsultar() As Boolean
        Get
            Return bConsultar
        End Get
        Set(ByVal Value As Boolean)
            bConsultar = Value
        End Set
    End Property

#End Region

#Region " Enumerações "

    Enum eMensagem As Byte
        Codigo = 0
        Mensagem = 1
    End Enum

    Enum eModo As Short
        eAguardando = False
        eAlterando = True
    End Enum

    Enum eEstado As Byte
        eInsercao = 1
        eEdicao = 2
        eExclusao = 3
        eReposicao = 4
        eImpressao = 5
        eVisualizacao = 6
        eProcessamento = 7
    End Enum

    Public Enum botoesCadastro As Byte
        inserir = 1
        excluir = 2
        alterar = 3
        gravar = 4
        sair = 5
    End Enum

#End Region

#Region " Declarações de variáveis "

    Dim iModo As eModo = eModo.eAguardando
    Dim iChave As Integer
    Dim sMensagemConfirmacaoExclusao As String = "Deseja excluir o registro atual ?"
    Dim bModoInsercao As Boolean = False
    Dim iEstado As eEstado = eEstado.eReposicao
    Dim alColecaoMensagem As New ArrayList(0)
    Dim bInserir As Boolean = True
    Dim bExcluir As Boolean = True
    Dim bAlterar As Boolean = True
    Dim bConsultar As Boolean = True
    Dim sMenu As String
    Dim iIDGrupoAcesso As Integer

#End Region

#Region " Eventos "

    Protected Event inserir(ByRef bCancel As Boolean)
    Protected Event excluir(ByRef bCancel As Boolean)
    Protected Event gravar(ByRef bCancel As Boolean)
    Protected Event cancelar(ByRef bCancel As Boolean)
    Protected Event sair()
    Protected Event alterar(ByRef bCancel As Boolean)
    Protected Event limpaCampo()
    Protected Event carregaDados(ByVal iChave As Integer)
    Protected Shadows Event alteraModo(ByVal eModoAtual As eModo)
    Protected Event setarFoco(ByVal byCodigoMensagem As Byte, ByVal sMensagem As String)
    Protected Event limpaProvedorDeErros()
    Protected Event setarProvedorDeErros()
    Protected Event perfil(ByVal sMenuChamador As String, ByVal iIdGrupoAcesso As Int16)
    Protected Event permissao(ByVal sMenuChamador As String, ByVal iIdGrupoAcesso As Int16)

#End Region

#Region " Propriedades/Métodos Públicos de acesso ao formulário "

    Public Overridable Property modoInsercao() As Boolean
        Get
            Return Me.bModoInsercao
        End Get
        Set(ByVal Value As Boolean)
            Me.bModoInsercao = Value
        End Set
    End Property

    Public Function botaoHabilitado(ByVal byBotao As botoesCadastro) As Boolean
        Select Case byBotao
            Case botoesCadastro.inserir
                Return cmdNovo.Enabled
            Case botoesCadastro.excluir
                Return cmdExcluir.Enabled
            Case botoesCadastro.alterar
                Return cmdCancelar.Enabled
            Case botoesCadastro.gravar
                Return cmdGravar.Enabled
            Case botoesCadastro.sair
                Return cmdSair.Enabled
            Case Else
                Return False
        End Select
    End Function

    Public Function botaoHabilitado(ByVal byBotao As botoesCadastro, ByVal bEstado As Boolean) As Boolean
        Select Case byBotao
            Case botoesCadastro.inserir
                cmdNovo.Enabled = bEstado
            Case botoesCadastro.excluir
                cmdExcluir.Enabled = bEstado
            Case botoesCadastro.alterar
                cmdCancelar.Enabled = bEstado
            Case botoesCadastro.gravar
                cmdGravar.Enabled = bEstado
            Case botoesCadastro.sair
                cmdSair.Enabled = bEstado
        End Select
        Return bEstado
    End Function

    Public Sub forcaInsercao()

        Dim bCancel As Boolean = False
        Dim objPrimeiraMensagem() As Object

        Me.estadoAtual = eEstado.eInsercao
        Me.cmdCancelar.Text = "Cancelar"
        Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Cancelar alterações")

        Me.modoAtual = eModo.eAlterando
        Me.alteraModopadrao(Me.modoAtual)

        RaiseEvent limpaProvedorDeErros()
        RaiseEvent limpaCampo()
        RaiseEvent inserir(bCancel)
        RaiseEvent alteraModo(Me.modoAtual)


        If bCancel Then

            If SeTemChaveDefinida() Then RaiseEvent carregaDados(chave)
            objPrimeiraMensagem = Me.primeiraMensagem

            RaiseEvent setarFoco(objPrimeiraMensagem(0), objPrimeiraMensagem(1))
            RaiseEvent setarProvedorDeErros()

            Me.cmdCancelar.Text = "Alterar"
            Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Altera registro atual")
            Me.modoAtual = eModo.eAguardando
            Me.estadoAtual = eEstado.eReposicao

        End If

    End Sub

    Public Sub forcaExclusao()

        Dim bCancel As Boolean = False
        Dim bMantemChaveSelecionada As Boolean = False
        Dim objPrimeiraMensagem() As Object

        Me.estadoAtual = eEstado.eExclusao
        Me.modoAtual = eModo.eAlterando
        Me.alteraModopadrao(Me.modoAtual)

        RaiseEvent alteraModo(Me.modoAtual)

        RaiseEvent excluir(bCancel)

        If bCancel Then

            objPrimeiraMensagem = Me.primeiraMensagem

            If Not objPrimeiraMensagem(0) Is Nothing Then
                RaiseEvent setarFoco(objPrimeiraMensagem(0), objPrimeiraMensagem(1))
                RaiseEvent setarProvedorDeErros()
            End If

        Else

            RaiseEvent limpaCampo()

            If bMantemChaveSelecionada Then
                If SeTemChaveDefinida() Then RaiseEvent carregaDados(Me.chave)
            Else
                Me.chave = 0
            End If

        End If

        Me.modoAtual = eModo.eAguardando
        Me.estadoAtual = eEstado.eReposicao
        Me.alteraModopadrao(Me.modoAtual)

        RaiseEvent alteraModo(Me.modoAtual)

    End Sub

    Public Sub forcaCancelamento()

        Dim bCancel As Boolean = False
        Dim objPrimeiraMensagem() As Object

        Me.estadoAtual = eEstado.eReposicao
        Me.cmdCancelar.Text = "Alterar"
        Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Altera registro atual")
        Me.modoAtual = eModo.eAguardando
        Me.alteraModopadrao(Me.modoAtual)

        RaiseEvent alteraModo(Me.modoAtual)
        RaiseEvent limpaProvedorDeErros()
        RaiseEvent cancelar(bCancel)

        If bCancel Then

            objPrimeiraMensagem = Me.primeiraMensagem

            If Not objPrimeiraMensagem(0) Is Nothing Then
                RaiseEvent setarFoco(objPrimeiraMensagem(0), objPrimeiraMensagem(1))
                RaiseEvent setarProvedorDeErros()
            End If

            Me.cmdCancelar.Text = "Cancelar"
            Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Cancelar alterações")
            Me.modoAtual = eModo.eAlterando
            Me.estadoAtual = eEstado.eEdicao
        Else
            RaiseEvent limpaCampo()
            If SeTemChaveDefinida() Then RaiseEvent carregaDados(chave)
        End If

    End Sub

    Public Sub forcaAlteracao()

        Dim bCancel As Boolean = False
        Dim objPrimeiraMensagem() As Object

        Me.estadoAtual = eEstado.eEdicao
        Me.cmdCancelar.Text = "Cancelar"
        Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Cancelar alterações")
        Me.modoAtual = eModo.eAlterando
        Me.alteraModopadrao(Me.modoAtual)

        RaiseEvent alteraModo(Me.modoAtual)
        RaiseEvent limpaProvedorDeErros()
        RaiseEvent alterar(bCancel)

        If bCancel Then
            objPrimeiraMensagem = Me.primeiraMensagem
            If Not objPrimeiraMensagem(0) Is Nothing Then
                RaiseEvent setarFoco(objPrimeiraMensagem(0), objPrimeiraMensagem(1))
                RaiseEvent setarProvedorDeErros()
            End If

            Me.cmdCancelar.Text = "Alterar"
            Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Altera registro atual")
            Me.modoAtual = eModo.eAguardando
            Me.estadoAtual = eEstado.eReposicao
        End If

    End Sub

    Public Sub forcaGravacao()

        Dim bCancel As Boolean = False
        Dim objPrimeiraMensagem() As Object

        RaiseEvent limpaProvedorDeErros()
        RaiseEvent gravar(bCancel)

        If bCancel Then
            objPrimeiraMensagem = Me.primeiraMensagem
            If Not objPrimeiraMensagem(0) Is Nothing Then
                RaiseEvent setarFoco(objPrimeiraMensagem(0), objPrimeiraMensagem(1))
                RaiseEvent setarProvedorDeErros()
            End If
        Else
            Me.estadoAtual = eEstado.eReposicao
            Me.cmdCancelar.Text = "Alterar"
            Me.ttPadrao.SetToolTip(Me.cmdCancelar, "Altera registro atual")
            Me.modoAtual = eModo.eAguardando
            Me.alteraModopadrao(Me.modoAtual)

            RaiseEvent alteraModo(Me.modoAtual)
            RaiseEvent limpaCampo()
            If SeTemChaveDefinida() Then RaiseEvent carregaDados(Me.chave)
        End If

    End Sub

    Public Sub forcaSaida()
        estadoAtual = eEstado.eReposicao
        Me.modoAtual = eModo.eAguardando
        Me.alteraModopadrao(Me.modoAtual)

        RaiseEvent alteraModo(Me.modoAtual)
        RaiseEvent sair()
        Me.Close()
    End Sub

    Public Function primeiraMensagem() As Object()

        Dim objRetorno(1) As Object

        If Me.Mensagens.Count <> 0 Then
            If Me.Mensagens.Item(0).Count <= 0 OrElse Me.Mensagens.Item(1).Count <= 0 Then
                Me.Mensagens.Clear()
            Else
                objRetorno(0) = Me.Mensagens.Item(0).item(0)
                objRetorno(1) = Me.Mensagens.Item(1).item(0)
            End If
        End If

        Return objRetorno

    End Function

#End Region

#Region " Métodos Privados de acesso ao formulario "

    Public Property mensagemConfirmacaoExclusao() As String
        Get
            Return sMensagemConfirmacaoExclusao
        End Get
        Set(ByVal Value As String)
            sMensagemConfirmacaoExclusao = Value
        End Set
    End Property

    Public Property modoAtual() As eModo
        Get
            Return iModo
        End Get
        Set(ByVal Value As eModo)
            iModo = Value
        End Set
    End Property

    Public Sub alteraModopadrao(ByVal modo As eModo)

        Me.cmdNovo.Enabled = Not modo And Me.acessoInserir
        Me.cmdExcluir.Enabled = Not modo And Me.acessoExcluir And SeTemChaveDefinida()
        Me.cmdGravar.Enabled = modo And (Me.acessoAlterar Or Me.acessoInserir)
        Me.cmdCancelar.Enabled = (Me.acessoAlterar AndAlso Me.cmdCancelar.Text = "Alterar" AndAlso SeTemChaveDefinida()) OrElse _
                                 (Me.acessoConsultar AndAlso Me.cmdCancelar.Text = "Cancelar")
        Me.cmdSair.Enabled = Not modo

    End Sub

    Friend Function SeTemChaveDefinida() As Boolean

        If Me.chave > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Me.forcaInsercao()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Me.forcaExclusao()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        If Me.cmdCancelar.Text = "Alterar" Then
            Me.forcaAlteracao()
        ElseIf Me.cmdCancelar.Text = "Cancelar" Then
            Me.forcaCancelamento()
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Me.forcaGravacao()
    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.forcaSaida()
    End Sub

    Private Sub padraoCadastroEvento_alteraModo(ByVal eModoAtual As eModo) Handles Me.alteraModo
        Me.modoAtual = eModoAtual
        Me.alteraModopadrao(Me.modoAtual)
        RaiseEvent limpaCampo()
        RaiseEvent carregaDados(Me.chave)
    End Sub

    Private Sub padraoCadastroEvento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RaiseEvent perfil(Me.menuChamador, Me.idGrupoAcesso)

        RaiseEvent permissao(Me.menuChamador, Me.idGrupoAcesso)

        Me.modoAtual = eModo.eAguardando
        Me.alteraModopadrao(Me.modoAtual)
        RaiseEvent alteraModo(Me.modoAtual)

        If Me.bModoInsercao Then
            Me.forcaInsercao()
        End If

    End Sub

    Private Sub padraoSegurancaAcesso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SelectNextControl(Me.ActiveControl, True, True, True, False)
        End If
    End Sub

    Protected Sub limpaCampos(ByVal controlp As Control)
        Dim ctl As Control
        For Each ctl In controlp.Controls
            If TypeOf ctl Is TextBox Then
                DirectCast(ctl, TextBox).Text = String.Empty
            ElseIf TypeOf ctl Is RichTextBox Then
                DirectCast(ctl, RichTextBox).Text = String.Empty
            ElseIf TypeOf ctl Is CheckBox Then
                DirectCast(ctl, CheckBox).Checked = False
            ElseIf TypeOf ctl Is ComboBox Then
                DirectCast(ctl, ComboBox).SelectedIndex = -1
            ElseIf TypeOf ctl Is MaskedTextBox Then
                DirectCast(ctl, MaskedTextBox).Clear()
            ElseIf TypeOf ctl Is PictureBox Then
                DirectCast(ctl, PictureBox).Image = Nothing
            ElseIf ctl.Controls.Count > 0 Then
                limpaCampos(ctl)
            End If
        Next
    End Sub

    Public Function converteGridParaDataset(ByRef dtgridValor As DataGridView, _
                                            ByVal sNomeTabela As String) As DataSet

        Dim dsRetorno As New DataSet
        Dim datValor As New DataTable
        Dim byColuna As Byte = 0
        Dim bLinhaComDados As Boolean = False
        Dim aCampos(dtgridValor.ColumnCount - 1) As Object
        Dim dsOrigem As New DataSet

        'Verifica quais parametros foram passados
        If sNomeTabela <> String.Empty Then
            datValor.TableName = sNomeTabela
        End If

        'Monta as colunas do DataTable
        With dtgridValor
            For byColuna = 0 To .ColumnCount - 1
                If .Columns(byColuna).ValueType Is Nothing Then
                    datValor.Columns.Add(.Columns(byColuna).HeaderText, GetType(String))
                Else
                    datValor.Columns.Add(.Columns(byColuna).HeaderText, .Columns(byColuna).ValueType)
                End If
            Next
        End With

        dsRetorno.Tables.Add(datValor)
        'Adiciona as linhas do DataSet
        With dsRetorno.Tables(0)

            For shtLinha = 0 To dtgridValor.Rows.Count - 1
                bLinhaComDados = False
                For byColuna = 0 To dtgridValor.ColumnCount - 1
                    If dtgridValor.Item(byColuna, shtLinha).Value Is Nothing Then
                        aCampos(byColuna) = DBNull.Value
                    Else
                        bLinhaComDados = True
                        aCampos(byColuna) = dtgridValor.Item(byColuna, shtLinha).Value
                    End If
                Next
                If bLinhaComDados Then
                    .Rows.Add(aCampos)
                End If
            Next
        End With

        Return dsRetorno

    End Function

#End Region

    Private Sub frmPadrao_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub

    Private Sub frmPadrao_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.Select()
    End Sub
End Class
