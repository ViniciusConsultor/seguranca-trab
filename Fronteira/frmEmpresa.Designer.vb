<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpresa
    Inherits DSFronteiraPadrao.frmPadrao

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbcEmpresa = New System.Windows.Forms.TabControl
        Me.tbcPrincipal = New System.Windows.Forms.TabPage
        Me.cmdSelecionarEmpresa = New System.Windows.Forms.Button
        Me.fraPrincipal = New System.Windows.Forms.GroupBox
        Me.txtTelefone = New System.Windows.Forms.MaskedTextBox
        Me.txtFax = New System.Windows.Forms.MaskedTextBox
        Me.txtCep = New System.Windows.Forms.MaskedTextBox
        Me.txtCNPJ = New System.Windows.Forms.MaskedTextBox
        Me.cmdLimparLogo = New System.Windows.Forms.Button
        Me.cmdSelecionarLogo = New System.Windows.Forms.Button
        Me.fraLogomarca = New System.Windows.Forms.GroupBox
        Me.pbLogomarca = New System.Windows.Forms.PictureBox
        Me.txtEmail = New DSTextBox.DSTextBox
        Me.lblEmail = New System.Windows.Forms.Label
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.lblFax = New System.Windows.Forms.Label
        Me.lblTelefone = New System.Windows.Forms.Label
        Me.lblCNPJ = New System.Windows.Forms.Label
        Me.lblCEP = New System.Windows.Forms.Label
        Me.txtCidade = New DSTextBox.DSTextBox
        Me.lblCidade = New System.Windows.Forms.Label
        Me.txtBairro = New DSTextBox.DSTextBox
        Me.lblBairro = New System.Windows.Forms.Label
        Me.txtNumero = New DSTextBox.DSTextBox
        Me.lblNumero = New System.Windows.Forms.Label
        Me.txtLogradouro = New DSTextBox.DSTextBox
        Me.lblLogradouro = New System.Windows.Forms.Label
        Me.txtSigla = New DSTextBox.DSTextBox
        Me.lblSigla = New System.Windows.Forms.Label
        Me.txtRazaoSocial = New DSTextBox.DSTextBox
        Me.lblRazao = New System.Windows.Forms.Label
        Me.txtNome = New DSTextBox.DSTextBox
        Me.lblEmpresa = New System.Windows.Forms.Label
        Me.tbcConfiguracoes = New System.Windows.Forms.TabPage
        Me.fraConfiguracoes = New System.Windows.Forms.GroupBox
        Me.cmdAssociarNR = New System.Windows.Forms.Button
        Me.fraAlerta = New System.Windows.Forms.GroupBox
        Me.chkAuditoria = New System.Windows.Forms.CheckBox
        Me.txtAlertaAuditoria = New DSTextBox.DSTextBox
        Me.lblMesesAuditoria = New System.Windows.Forms.Label
        Me.chkDocumentos = New System.Windows.Forms.CheckBox
        Me.txtAlertaDocumento = New DSTextBox.DSTextBox
        Me.lblMesesDocumento = New System.Windows.Forms.Label
        Me.chkEPI = New System.Windows.Forms.CheckBox
        Me.txtAlertaEPI = New DSTextBox.DSTextBox
        Me.lblMesesEPI = New System.Windows.Forms.Label
        Me.chkTreinamentos = New System.Windows.Forms.CheckBox
        Me.txtAlertaTreinamento = New DSTextBox.DSTextBox
        Me.lblMesesTreinamento = New System.Windows.Forms.Label
        Me.txtDuracaoCheckList = New DSTextBox.DSTextBox
        Me.lblMeses = New System.Windows.Forms.Label
        Me.lblTempo = New System.Windows.Forms.Label
        Me.tbcDocumento = New System.Windows.Forms.TabPage
        Me.cmdExportarSelecionados = New System.Windows.Forms.Button
        Me.cmdSelecionarTodos = New System.Windows.Forms.Button
        Me.cmdExcluirDocumento = New System.Windows.Forms.Button
        Me.fraDocumentos = New System.Windows.Forms.GroupBox
        Me.cmdAdicionarDocumentos = New System.Windows.Forms.Button
        Me.dgvDocumentos = New System.Windows.Forms.DataGridView
        Me.fbdDocumentos = New System.Windows.Forms.FolderBrowserDialog
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcEmpresa.SuspendLayout()
        Me.tbcPrincipal.SuspendLayout()
        Me.fraPrincipal.SuspendLayout()
        Me.fraLogomarca.SuspendLayout()
        CType(Me.pbLogomarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcConfiguracoes.SuspendLayout()
        Me.fraConfiguracoes.SuspendLayout()
        Me.fraAlerta.SuspendLayout()
        Me.tbcDocumento.SuspendLayout()
        Me.fraDocumentos.SuspendLayout()
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.tbcEmpresa)
        Me.fraGeral.Size = New System.Drawing.Size(569, 275)
        '
        'tbcEmpresa
        '
        Me.tbcEmpresa.Controls.Add(Me.tbcPrincipal)
        Me.tbcEmpresa.Controls.Add(Me.tbcConfiguracoes)
        Me.tbcEmpresa.Controls.Add(Me.tbcDocumento)
        Me.tbcEmpresa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcEmpresa.Location = New System.Drawing.Point(3, 16)
        Me.tbcEmpresa.Name = "tbcEmpresa"
        Me.tbcEmpresa.SelectedIndex = 0
        Me.tbcEmpresa.Size = New System.Drawing.Size(563, 256)
        Me.tbcEmpresa.TabIndex = 1
        '
        'tbcPrincipal
        '
        Me.tbcPrincipal.Controls.Add(Me.cmdSelecionarEmpresa)
        Me.tbcPrincipal.Controls.Add(Me.fraPrincipal)
        Me.tbcPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tbcPrincipal.Name = "tbcPrincipal"
        Me.tbcPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbcPrincipal.Size = New System.Drawing.Size(555, 230)
        Me.tbcPrincipal.TabIndex = 0
        Me.tbcPrincipal.Text = "Principal"
        Me.tbcPrincipal.UseVisualStyleBackColor = True
        '
        'cmdSelecionarEmpresa
        '
        Me.cmdSelecionarEmpresa.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelecionarEmpresa.Location = New System.Drawing.Point(393, 17)
        Me.cmdSelecionarEmpresa.Name = "cmdSelecionarEmpresa"
        Me.cmdSelecionarEmpresa.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarEmpresa.TabIndex = 66
        Me.cmdSelecionarEmpresa.UseVisualStyleBackColor = True
        '
        'fraPrincipal
        '
        Me.fraPrincipal.Controls.Add(Me.txtTelefone)
        Me.fraPrincipal.Controls.Add(Me.txtFax)
        Me.fraPrincipal.Controls.Add(Me.txtCep)
        Me.fraPrincipal.Controls.Add(Me.txtCNPJ)
        Me.fraPrincipal.Controls.Add(Me.cmdLimparLogo)
        Me.fraPrincipal.Controls.Add(Me.cmdSelecionarLogo)
        Me.fraPrincipal.Controls.Add(Me.fraLogomarca)
        Me.fraPrincipal.Controls.Add(Me.txtEmail)
        Me.fraPrincipal.Controls.Add(Me.lblEmail)
        Me.fraPrincipal.Controls.Add(Me.cboEstado)
        Me.fraPrincipal.Controls.Add(Me.lblEstado)
        Me.fraPrincipal.Controls.Add(Me.lblFax)
        Me.fraPrincipal.Controls.Add(Me.lblTelefone)
        Me.fraPrincipal.Controls.Add(Me.lblCNPJ)
        Me.fraPrincipal.Controls.Add(Me.lblCEP)
        Me.fraPrincipal.Controls.Add(Me.txtCidade)
        Me.fraPrincipal.Controls.Add(Me.lblCidade)
        Me.fraPrincipal.Controls.Add(Me.txtBairro)
        Me.fraPrincipal.Controls.Add(Me.lblBairro)
        Me.fraPrincipal.Controls.Add(Me.txtNumero)
        Me.fraPrincipal.Controls.Add(Me.lblNumero)
        Me.fraPrincipal.Controls.Add(Me.txtLogradouro)
        Me.fraPrincipal.Controls.Add(Me.lblLogradouro)
        Me.fraPrincipal.Controls.Add(Me.txtSigla)
        Me.fraPrincipal.Controls.Add(Me.lblSigla)
        Me.fraPrincipal.Controls.Add(Me.txtRazaoSocial)
        Me.fraPrincipal.Controls.Add(Me.lblRazao)
        Me.fraPrincipal.Controls.Add(Me.txtNome)
        Me.fraPrincipal.Controls.Add(Me.lblEmpresa)
        Me.fraPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(549, 224)
        Me.fraPrincipal.TabIndex = 33
        Me.fraPrincipal.TabStop = False
        '
        'txtTelefone
        '
        Me.txtTelefone.Location = New System.Drawing.Point(88, 200)
        Me.txtTelefone.Mask = "(##)####-####"
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefone.TabIndex = 12
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(238, 199)
        Me.txtFax.Mask = "(##)####-####"
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(150, 20)
        Me.txtFax.TabIndex = 13
        '
        'txtCep
        '
        Me.txtCep.Location = New System.Drawing.Point(238, 176)
        Me.txtCep.Mask = "##.###-###"
        Me.txtCep.Name = "txtCep"
        Me.txtCep.Size = New System.Drawing.Size(150, 20)
        Me.txtCep.TabIndex = 11
        '
        'txtCNPJ
        '
        Me.txtCNPJ.Location = New System.Drawing.Point(238, 62)
        Me.txtCNPJ.Mask = "##.###.###/####-##"
        Me.txtCNPJ.Name = "txtCNPJ"
        Me.txtCNPJ.Size = New System.Drawing.Size(149, 20)
        Me.txtCNPJ.TabIndex = 4
        '
        'cmdLimparLogo
        '
        Me.cmdLimparLogo.Image = Global.Fronteira.My.Resources.Resources.Limpar
        Me.cmdLimparLogo.Location = New System.Drawing.Point(523, 110)
        Me.cmdLimparLogo.Name = "cmdLimparLogo"
        Me.cmdLimparLogo.Size = New System.Drawing.Size(22, 23)
        Me.cmdLimparLogo.TabIndex = 63
        Me.ttPadrao.SetToolTip(Me.cmdLimparLogo, "Limpar logomarca da empresa")
        Me.cmdLimparLogo.UseVisualStyleBackColor = True
        '
        'cmdSelecionarLogo
        '
        Me.cmdSelecionarLogo.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarLogo.Location = New System.Drawing.Point(500, 110)
        Me.cmdSelecionarLogo.Name = "cmdSelecionarLogo"
        Me.cmdSelecionarLogo.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarLogo.TabIndex = 14
        Me.ttPadrao.SetToolTip(Me.cmdSelecionarLogo, "Selecionar logomarca da empresa")
        Me.cmdSelecionarLogo.UseVisualStyleBackColor = True
        '
        'fraLogomarca
        '
        Me.fraLogomarca.Controls.Add(Me.pbLogomarca)
        Me.fraLogomarca.Location = New System.Drawing.Point(435, 8)
        Me.fraLogomarca.Name = "fraLogomarca"
        Me.fraLogomarca.Size = New System.Drawing.Size(109, 100)
        Me.fraLogomarca.TabIndex = 61
        Me.fraLogomarca.TabStop = False
        '
        'pbLogomarca
        '
        Me.pbLogomarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbLogomarca.Location = New System.Drawing.Point(3, 16)
        Me.pbLogomarca.Name = "pbLogomarca"
        Me.pbLogomarca.Size = New System.Drawing.Size(103, 81)
        Me.pbLogomarca.TabIndex = 0
        Me.pbLogomarca.TabStop = False
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(88, 85)
        Me.txtEmail.MaxLength = 30
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(300, 20)
        Me.txtEmail.TabIndex = 5
        Me.txtEmail.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(51, 87)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(38, 13)
        Me.lblEmail.TabIndex = 59
        Me.lblEmail.Text = "E-mail:"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(88, 177)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(83, 21)
        Me.cboEstado.TabIndex = 10
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(46, 179)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblEstado.TabIndex = 58
        Me.lblEstado.Text = "Estado:"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(207, 202)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(27, 13)
        Me.lblFax.TabIndex = 57
        Me.lblFax.Text = "Fax:"
        '
        'lblTelefone
        '
        Me.lblTelefone.AutoSize = True
        Me.lblTelefone.Location = New System.Drawing.Point(37, 202)
        Me.lblTelefone.Name = "lblTelefone"
        Me.lblTelefone.Size = New System.Drawing.Size(52, 13)
        Me.lblTelefone.TabIndex = 56
        Me.lblTelefone.Text = "Telefone:"
        '
        'lblCNPJ
        '
        Me.lblCNPJ.AutoSize = True
        Me.lblCNPJ.Location = New System.Drawing.Point(197, 64)
        Me.lblCNPJ.Name = "lblCNPJ"
        Me.lblCNPJ.Size = New System.Drawing.Size(37, 13)
        Me.lblCNPJ.TabIndex = 55
        Me.lblCNPJ.Text = "CNPJ:"
        Me.lblCNPJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCEP
        '
        Me.lblCEP.AutoSize = True
        Me.lblCEP.Location = New System.Drawing.Point(203, 179)
        Me.lblCEP.Name = "lblCEP"
        Me.lblCEP.Size = New System.Drawing.Size(31, 13)
        Me.lblCEP.TabIndex = 54
        Me.lblCEP.Text = "CEP:"
        '
        'txtCidade
        '
        Me.txtCidade.Location = New System.Drawing.Point(88, 154)
        Me.txtCidade.MaxLength = 30
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(300, 20)
        Me.txtCidade.TabIndex = 9
        Me.txtCidade.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblCidade
        '
        Me.lblCidade.AutoSize = True
        Me.lblCidade.Location = New System.Drawing.Point(46, 156)
        Me.lblCidade.Name = "lblCidade"
        Me.lblCidade.Size = New System.Drawing.Size(43, 13)
        Me.lblCidade.TabIndex = 53
        Me.lblCidade.Text = "Cidade:"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(238, 130)
        Me.txtBairro.MaxLength = 30
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(150, 20)
        Me.txtBairro.TabIndex = 8
        Me.txtBairro.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblBairro
        '
        Me.lblBairro.AutoSize = True
        Me.lblBairro.Location = New System.Drawing.Point(197, 131)
        Me.lblBairro.Name = "lblBairro"
        Me.lblBairro.Size = New System.Drawing.Size(37, 13)
        Me.lblBairro.TabIndex = 52
        Me.lblBairro.Text = "Bairro:"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(88, 131)
        Me.txtNumero.MaxLength = 10
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 7
        Me.txtNumero.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(42, 133)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(47, 13)
        Me.lblNumero.TabIndex = 51
        Me.lblNumero.Text = "Número:"
        '
        'txtLogradouro
        '
        Me.txtLogradouro.Location = New System.Drawing.Point(88, 108)
        Me.txtLogradouro.MaxLength = 30
        Me.txtLogradouro.Name = "txtLogradouro"
        Me.txtLogradouro.Size = New System.Drawing.Size(300, 20)
        Me.txtLogradouro.TabIndex = 6
        Me.txtLogradouro.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblLogradouro
        '
        Me.lblLogradouro.AutoSize = True
        Me.lblLogradouro.Location = New System.Drawing.Point(25, 110)
        Me.lblLogradouro.Name = "lblLogradouro"
        Me.lblLogradouro.Size = New System.Drawing.Size(64, 13)
        Me.lblLogradouro.TabIndex = 50
        Me.lblLogradouro.Text = "Logradouro:"
        '
        'txtSigla
        '
        Me.txtSigla.Location = New System.Drawing.Point(88, 62)
        Me.txtSigla.MaxLength = 5
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.Size = New System.Drawing.Size(100, 20)
        Me.txtSigla.TabIndex = 3
        Me.txtSigla.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblSigla
        '
        Me.lblSigla.AutoSize = True
        Me.lblSigla.Location = New System.Drawing.Point(50, 64)
        Me.lblSigla.Name = "lblSigla"
        Me.lblSigla.Size = New System.Drawing.Size(33, 13)
        Me.lblSigla.TabIndex = 48
        Me.lblSigla.Text = "Sigla:"
        '
        'txtRazaoSocial
        '
        Me.txtRazaoSocial.Location = New System.Drawing.Point(88, 39)
        Me.txtRazaoSocial.MaxLength = 50
        Me.txtRazaoSocial.Name = "txtRazaoSocial"
        Me.txtRazaoSocial.Size = New System.Drawing.Size(300, 20)
        Me.txtRazaoSocial.TabIndex = 2
        Me.txtRazaoSocial.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblRazao
        '
        Me.lblRazao.AutoSize = True
        Me.lblRazao.Location = New System.Drawing.Point(18, 41)
        Me.lblRazao.Name = "lblRazao"
        Me.lblRazao.Size = New System.Drawing.Size(71, 13)
        Me.lblRazao.TabIndex = 45
        Me.lblRazao.Text = "Razão social:"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(88, 16)
        Me.txtNome.MaxLength = 30
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(300, 20)
        Me.txtNome.TabIndex = 1
        Me.txtNome.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(11, 18)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(78, 13)
        Me.lblEmpresa.TabIndex = 42
        Me.lblEmpresa.Text = "Nome fantasia:"
        '
        'tbcConfiguracoes
        '
        Me.tbcConfiguracoes.Controls.Add(Me.fraConfiguracoes)
        Me.tbcConfiguracoes.Location = New System.Drawing.Point(4, 22)
        Me.tbcConfiguracoes.Name = "tbcConfiguracoes"
        Me.tbcConfiguracoes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbcConfiguracoes.Size = New System.Drawing.Size(555, 230)
        Me.tbcConfiguracoes.TabIndex = 2
        Me.tbcConfiguracoes.Text = "Configurações"
        Me.tbcConfiguracoes.UseVisualStyleBackColor = True
        '
        'fraConfiguracoes
        '
        Me.fraConfiguracoes.Controls.Add(Me.cmdAssociarNR)
        Me.fraConfiguracoes.Controls.Add(Me.fraAlerta)
        Me.fraConfiguracoes.Controls.Add(Me.txtDuracaoCheckList)
        Me.fraConfiguracoes.Controls.Add(Me.lblMeses)
        Me.fraConfiguracoes.Controls.Add(Me.lblTempo)
        Me.fraConfiguracoes.Location = New System.Drawing.Point(3, 3)
        Me.fraConfiguracoes.Name = "fraConfiguracoes"
        Me.fraConfiguracoes.Size = New System.Drawing.Size(549, 224)
        Me.fraConfiguracoes.TabIndex = 69
        Me.fraConfiguracoes.TabStop = False
        '
        'cmdAssociarNR
        '
        Me.cmdAssociarNR.Location = New System.Drawing.Point(9, 12)
        Me.cmdAssociarNR.Name = "cmdAssociarNR"
        Me.cmdAssociarNR.Size = New System.Drawing.Size(149, 26)
        Me.cmdAssociarNR.TabIndex = 72
        Me.cmdAssociarNR.Text = "Associar NR"
        Me.cmdAssociarNR.UseVisualStyleBackColor = True
        '
        'fraAlerta
        '
        Me.fraAlerta.Controls.Add(Me.chkAuditoria)
        Me.fraAlerta.Controls.Add(Me.txtAlertaAuditoria)
        Me.fraAlerta.Controls.Add(Me.lblMesesAuditoria)
        Me.fraAlerta.Controls.Add(Me.chkDocumentos)
        Me.fraAlerta.Controls.Add(Me.txtAlertaDocumento)
        Me.fraAlerta.Controls.Add(Me.lblMesesDocumento)
        Me.fraAlerta.Controls.Add(Me.chkEPI)
        Me.fraAlerta.Controls.Add(Me.txtAlertaEPI)
        Me.fraAlerta.Controls.Add(Me.lblMesesEPI)
        Me.fraAlerta.Controls.Add(Me.chkTreinamentos)
        Me.fraAlerta.Controls.Add(Me.txtAlertaTreinamento)
        Me.fraAlerta.Controls.Add(Me.lblMesesTreinamento)
        Me.fraAlerta.Location = New System.Drawing.Point(9, 50)
        Me.fraAlerta.Name = "fraAlerta"
        Me.fraAlerta.Size = New System.Drawing.Size(534, 75)
        Me.fraAlerta.TabIndex = 73
        Me.fraAlerta.TabStop = False
        Me.fraAlerta.Text = "Tempo para exibição do alerta"
        Me.fraAlerta.Visible = False
        '
        'chkAuditoria
        '
        Me.chkAuditoria.AutoSize = True
        Me.chkAuditoria.Location = New System.Drawing.Point(228, 45)
        Me.chkAuditoria.Name = "chkAuditoria"
        Me.chkAuditoria.Size = New System.Drawing.Size(67, 17)
        Me.chkAuditoria.TabIndex = 88
        Me.chkAuditoria.Text = "Auditoria"
        Me.chkAuditoria.UseVisualStyleBackColor = True
        '
        'txtAlertaAuditoria
        '
        Me.txtAlertaAuditoria.Enabled = False
        Me.txtAlertaAuditoria.Location = New System.Drawing.Point(324, 42)
        Me.txtAlertaAuditoria.MaxLength = 5
        Me.txtAlertaAuditoria.Name = "txtAlertaAuditoria"
        Me.txtAlertaAuditoria.Size = New System.Drawing.Size(38, 20)
        Me.txtAlertaAuditoria.TabIndex = 87
        Me.txtAlertaAuditoria.Text = "6"
        Me.txtAlertaAuditoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlertaAuditoria.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblMesesAuditoria
        '
        Me.lblMesesAuditoria.AutoSize = True
        Me.lblMesesAuditoria.Enabled = False
        Me.lblMesesAuditoria.Location = New System.Drawing.Point(368, 46)
        Me.lblMesesAuditoria.Name = "lblMesesAuditoria"
        Me.lblMesesAuditoria.Size = New System.Drawing.Size(37, 13)
        Me.lblMesesAuditoria.TabIndex = 86
        Me.lblMesesAuditoria.Text = "meses"
        '
        'chkDocumentos
        '
        Me.chkDocumentos.AutoSize = True
        Me.chkDocumentos.Location = New System.Drawing.Point(228, 23)
        Me.chkDocumentos.Name = "chkDocumentos"
        Me.chkDocumentos.Size = New System.Drawing.Size(86, 17)
        Me.chkDocumentos.TabIndex = 82
        Me.chkDocumentos.Text = "Documentos"
        Me.chkDocumentos.UseVisualStyleBackColor = True
        '
        'txtAlertaDocumento
        '
        Me.txtAlertaDocumento.Enabled = False
        Me.txtAlertaDocumento.Location = New System.Drawing.Point(324, 20)
        Me.txtAlertaDocumento.MaxLength = 5
        Me.txtAlertaDocumento.Name = "txtAlertaDocumento"
        Me.txtAlertaDocumento.Size = New System.Drawing.Size(38, 20)
        Me.txtAlertaDocumento.TabIndex = 81
        Me.txtAlertaDocumento.Text = "6"
        Me.txtAlertaDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlertaDocumento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblMesesDocumento
        '
        Me.lblMesesDocumento.AutoSize = True
        Me.lblMesesDocumento.Enabled = False
        Me.lblMesesDocumento.Location = New System.Drawing.Point(368, 24)
        Me.lblMesesDocumento.Name = "lblMesesDocumento"
        Me.lblMesesDocumento.Size = New System.Drawing.Size(37, 13)
        Me.lblMesesDocumento.TabIndex = 80
        Me.lblMesesDocumento.Text = "meses"
        '
        'chkEPI
        '
        Me.chkEPI.AutoSize = True
        Me.chkEPI.Location = New System.Drawing.Point(6, 45)
        Me.chkEPI.Name = "chkEPI"
        Me.chkEPI.Size = New System.Drawing.Size(51, 17)
        Me.chkEPI.TabIndex = 79
        Me.chkEPI.Text = "EPI´s"
        Me.chkEPI.UseVisualStyleBackColor = True
        '
        'txtAlertaEPI
        '
        Me.txtAlertaEPI.Enabled = False
        Me.txtAlertaEPI.Location = New System.Drawing.Point(102, 42)
        Me.txtAlertaEPI.MaxLength = 5
        Me.txtAlertaEPI.Name = "txtAlertaEPI"
        Me.txtAlertaEPI.Size = New System.Drawing.Size(38, 20)
        Me.txtAlertaEPI.TabIndex = 78
        Me.txtAlertaEPI.Text = "6"
        Me.txtAlertaEPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlertaEPI.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblMesesEPI
        '
        Me.lblMesesEPI.AutoSize = True
        Me.lblMesesEPI.Enabled = False
        Me.lblMesesEPI.Location = New System.Drawing.Point(146, 46)
        Me.lblMesesEPI.Name = "lblMesesEPI"
        Me.lblMesesEPI.Size = New System.Drawing.Size(37, 13)
        Me.lblMesesEPI.TabIndex = 77
        Me.lblMesesEPI.Text = "meses"
        '
        'chkTreinamentos
        '
        Me.chkTreinamentos.AutoSize = True
        Me.chkTreinamentos.Location = New System.Drawing.Point(6, 23)
        Me.chkTreinamentos.Name = "chkTreinamentos"
        Me.chkTreinamentos.Size = New System.Drawing.Size(90, 17)
        Me.chkTreinamentos.TabIndex = 76
        Me.chkTreinamentos.Text = "Treinamentos"
        Me.chkTreinamentos.UseVisualStyleBackColor = True
        '
        'txtAlertaTreinamento
        '
        Me.txtAlertaTreinamento.Enabled = False
        Me.txtAlertaTreinamento.Location = New System.Drawing.Point(102, 20)
        Me.txtAlertaTreinamento.MaxLength = 5
        Me.txtAlertaTreinamento.Name = "txtAlertaTreinamento"
        Me.txtAlertaTreinamento.Size = New System.Drawing.Size(38, 20)
        Me.txtAlertaTreinamento.TabIndex = 75
        Me.txtAlertaTreinamento.Text = "6"
        Me.txtAlertaTreinamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAlertaTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblMesesTreinamento
        '
        Me.lblMesesTreinamento.AutoSize = True
        Me.lblMesesTreinamento.Enabled = False
        Me.lblMesesTreinamento.Location = New System.Drawing.Point(146, 24)
        Me.lblMesesTreinamento.Name = "lblMesesTreinamento"
        Me.lblMesesTreinamento.Size = New System.Drawing.Size(37, 13)
        Me.lblMesesTreinamento.TabIndex = 74
        Me.lblMesesTreinamento.Text = "meses"
        '
        'txtDuracaoCheckList
        '
        Me.txtDuracaoCheckList.Location = New System.Drawing.Point(190, 12)
        Me.txtDuracaoCheckList.MaxLength = 5
        Me.txtDuracaoCheckList.Name = "txtDuracaoCheckList"
        Me.txtDuracaoCheckList.Size = New System.Drawing.Size(38, 20)
        Me.txtDuracaoCheckList.TabIndex = 72
        Me.txtDuracaoCheckList.Text = "6"
        Me.txtDuracaoCheckList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDuracaoCheckList.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        Me.txtDuracaoCheckList.Visible = False
        '
        'lblMeses
        '
        Me.lblMeses.AutoSize = True
        Me.lblMeses.Location = New System.Drawing.Point(234, 16)
        Me.lblMeses.Name = "lblMeses"
        Me.lblMeses.Size = New System.Drawing.Size(37, 13)
        Me.lblMeses.TabIndex = 71
        Me.lblMeses.Text = "meses"
        Me.lblMeses.Visible = False
        '
        'lblTempo
        '
        Me.lblTempo.AutoSize = True
        Me.lblTempo.Location = New System.Drawing.Point(6, 16)
        Me.lblTempo.Name = "lblTempo"
        Me.lblTempo.Size = New System.Drawing.Size(178, 13)
        Me.lblTempo.TabIndex = 70
        Me.lblTempo.Text = "Tempo para realização do check-list"
        Me.lblTempo.Visible = False
        '
        'tbcDocumento
        '
        Me.tbcDocumento.Controls.Add(Me.cmdExportarSelecionados)
        Me.tbcDocumento.Controls.Add(Me.cmdSelecionarTodos)
        Me.tbcDocumento.Controls.Add(Me.cmdExcluirDocumento)
        Me.tbcDocumento.Controls.Add(Me.fraDocumentos)
        Me.tbcDocumento.Location = New System.Drawing.Point(4, 22)
        Me.tbcDocumento.Name = "tbcDocumento"
        Me.tbcDocumento.Size = New System.Drawing.Size(555, 230)
        Me.tbcDocumento.TabIndex = 1
        Me.tbcDocumento.Text = "Documentos"
        Me.tbcDocumento.UseVisualStyleBackColor = True
        '
        'cmdExportarSelecionados
        '
        Me.cmdExportarSelecionados.Location = New System.Drawing.Point(417, 206)
        Me.cmdExportarSelecionados.Name = "cmdExportarSelecionados"
        Me.cmdExportarSelecionados.Size = New System.Drawing.Size(120, 23)
        Me.cmdExportarSelecionados.TabIndex = 49
        Me.cmdExportarSelecionados.Text = "Exportar selecionados"
        Me.cmdExportarSelecionados.UseVisualStyleBackColor = True
        '
        'cmdSelecionarTodos
        '
        Me.cmdSelecionarTodos.Location = New System.Drawing.Point(319, 206)
        Me.cmdSelecionarTodos.Name = "cmdSelecionarTodos"
        Me.cmdSelecionarTodos.Size = New System.Drawing.Size(96, 23)
        Me.cmdSelecionarTodos.TabIndex = 48
        Me.cmdSelecionarTodos.Text = "Selecionar todos"
        Me.cmdSelecionarTodos.UseVisualStyleBackColor = True
        '
        'cmdExcluirDocumento
        '
        Me.cmdExcluirDocumento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirDocumento.BackColor = System.Drawing.Color.Transparent
        Me.cmdExcluirDocumento.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirDocumento.Location = New System.Drawing.Point(516, 1)
        Me.cmdExcluirDocumento.Name = "cmdExcluirDocumento"
        Me.cmdExcluirDocumento.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirDocumento.TabIndex = 46
        Me.cmdExcluirDocumento.Tag = ""
        Me.cmdExcluirDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirDocumento.UseVisualStyleBackColor = False
        '
        'fraDocumentos
        '
        Me.fraDocumentos.Controls.Add(Me.cmdAdicionarDocumentos)
        Me.fraDocumentos.Controls.Add(Me.dgvDocumentos)
        Me.fraDocumentos.Location = New System.Drawing.Point(0, 0)
        Me.fraDocumentos.Name = "fraDocumentos"
        Me.fraDocumentos.Size = New System.Drawing.Size(555, 250)
        Me.fraDocumentos.TabIndex = 3
        Me.fraDocumentos.TabStop = False
        '
        'cmdAdicionarDocumentos
        '
        Me.cmdAdicionarDocumentos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarDocumentos.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdicionarDocumentos.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarDocumentos.Location = New System.Drawing.Point(495, 1)
        Me.cmdAdicionarDocumentos.Name = "cmdAdicionarDocumentos"
        Me.cmdAdicionarDocumentos.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarDocumentos.TabIndex = 44
        Me.cmdAdicionarDocumentos.Tag = ""
        Me.cmdAdicionarDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarDocumentos.UseVisualStyleBackColor = False
        '
        'dgvDocumentos
        '
        Me.dgvDocumentos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocumentos.Location = New System.Drawing.Point(3, 20)
        Me.dgvDocumentos.Name = "dgvDocumentos"
        Me.dgvDocumentos.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvDocumentos.Size = New System.Drawing.Size(533, 180)
        Me.dgvDocumentos.TabIndex = 43
        '
        'frmEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 275)
        Me.Name = "frmEmpresa"
        Me.Text = "Cadastro de Empresa"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcEmpresa.ResumeLayout(False)
        Me.tbcPrincipal.ResumeLayout(False)
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.fraLogomarca.ResumeLayout(False)
        CType(Me.pbLogomarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcConfiguracoes.ResumeLayout(False)
        Me.fraConfiguracoes.ResumeLayout(False)
        Me.fraConfiguracoes.PerformLayout()
        Me.fraAlerta.ResumeLayout(False)
        Me.fraAlerta.PerformLayout()
        Me.tbcDocumento.ResumeLayout(False)
        Me.fraDocumentos.ResumeLayout(False)
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcEmpresa As System.Windows.Forms.TabControl
    Friend WithEvents tbcPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents txtEmail As DSTextBox.DSTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblTelefone As System.Windows.Forms.Label
    Friend WithEvents lblCNPJ As System.Windows.Forms.Label
    Friend WithEvents lblCEP As System.Windows.Forms.Label
    Friend WithEvents txtCidade As DSTextBox.DSTextBox
    Friend WithEvents lblCidade As System.Windows.Forms.Label
    Friend WithEvents txtBairro As DSTextBox.DSTextBox
    Friend WithEvents lblBairro As System.Windows.Forms.Label
    Friend WithEvents txtNumero As DSTextBox.DSTextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtLogradouro As DSTextBox.DSTextBox
    Friend WithEvents lblLogradouro As System.Windows.Forms.Label
    Friend WithEvents txtSigla As DSTextBox.DSTextBox
    Friend WithEvents lblSigla As System.Windows.Forms.Label
    Friend WithEvents txtRazaoSocial As DSTextBox.DSTextBox
    Friend WithEvents lblRazao As System.Windows.Forms.Label
    Friend WithEvents txtNome As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents fraLogomarca As System.Windows.Forms.GroupBox
    Friend WithEvents pbLogomarca As System.Windows.Forms.PictureBox
    Friend WithEvents cmdSelecionarLogo As System.Windows.Forms.Button
    Friend WithEvents cmdLimparLogo As System.Windows.Forms.Button
    Friend WithEvents tbcDocumento As System.Windows.Forms.TabPage
    Friend WithEvents fraDocumentos As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdAdicionarDocumentos As System.Windows.Forms.Button
    Friend WithEvents dgvDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents fbdDocumentos As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdSelecionarEmpresa As System.Windows.Forms.Button
    Protected Friend WithEvents cmdExcluirDocumento As System.Windows.Forms.Button
    Friend WithEvents cmdExportarSelecionados As System.Windows.Forms.Button
    Friend WithEvents cmdSelecionarTodos As System.Windows.Forms.Button
    Friend WithEvents tbcConfiguracoes As System.Windows.Forms.TabPage
    Friend WithEvents fraConfiguracoes As System.Windows.Forms.GroupBox
    Friend WithEvents txtDuracaoCheckList As DSTextBox.DSTextBox
    Friend WithEvents lblMeses As System.Windows.Forms.Label
    Friend WithEvents lblTempo As System.Windows.Forms.Label
    Friend WithEvents cmdAssociarNR As System.Windows.Forms.Button
    Friend WithEvents fraAlerta As System.Windows.Forms.GroupBox
    Friend WithEvents chkDocumentos As System.Windows.Forms.CheckBox
    Friend WithEvents txtAlertaDocumento As DSTextBox.DSTextBox
    Friend WithEvents lblMesesDocumento As System.Windows.Forms.Label
    Friend WithEvents chkEPI As System.Windows.Forms.CheckBox
    Friend WithEvents txtAlertaEPI As DSTextBox.DSTextBox
    Friend WithEvents lblMesesEPI As System.Windows.Forms.Label
    Friend WithEvents chkTreinamentos As System.Windows.Forms.CheckBox
    Friend WithEvents txtAlertaTreinamento As DSTextBox.DSTextBox
    Friend WithEvents lblMesesTreinamento As System.Windows.Forms.Label
    Friend WithEvents chkAuditoria As System.Windows.Forms.CheckBox
    Friend WithEvents txtAlertaAuditoria As DSTextBox.DSTextBox
    Friend WithEvents lblMesesAuditoria As System.Windows.Forms.Label
    Friend WithEvents txtCNPJ As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFax As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTelefone As System.Windows.Forms.MaskedTextBox
End Class
