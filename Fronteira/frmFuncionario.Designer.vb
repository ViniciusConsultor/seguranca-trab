<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFuncionario
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
        Me.tbcFuncionario = New System.Windows.Forms.TabControl
        Me.tbpPrincipal = New System.Windows.Forms.TabPage
        Me.fraTab1 = New System.Windows.Forms.GroupBox
        Me.cmdSelecionarFuncionario = New System.Windows.Forms.Button
        Me.fraPrincipal = New System.Windows.Forms.GroupBox
        Me.txtCTPS = New DSTextBox.DSTextBox
        Me.lblCTPS = New System.Windows.Forms.Label
        Me.txtDataEmissao = New System.Windows.Forms.DateTimePicker
        Me.lblDataEmissao = New System.Windows.Forms.Label
        Me.txtOrgao = New DSTextBox.DSTextBox
        Me.lblOrgao = New System.Windows.Forms.Label
        Me.txtRG = New DSTextBox.DSTextBox
        Me.txtCpf = New System.Windows.Forms.MaskedTextBox
        Me.lblRG = New System.Windows.Forms.Label
        Me.lblRazao = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.MaskedTextBox
        Me.lblCelular = New System.Windows.Forms.Label
        Me.txtTelefone = New System.Windows.Forms.MaskedTextBox
        Me.lblTelefone = New System.Windows.Forms.Label
        Me.txtCep = New System.Windows.Forms.MaskedTextBox
        Me.grpEmpresa = New System.Windows.Forms.GroupBox
        Me.cmdSelecionarFuncao = New System.Windows.Forms.Button
        Me.txtAdmissao = New System.Windows.Forms.DateTimePicker
        Me.txtRescisao = New System.Windows.Forms.DateTimePicker
        Me.txtRegistro = New DSTextBox.DSTextBox
        Me.lblRegistro = New System.Windows.Forms.Label
        Me.cmdLimparFuncao = New System.Windows.Forms.Button
        Me.txtFuncao = New DSTextBox.DSTextBox
        Me.lblFuncao = New System.Windows.Forms.Label
        Me.lblRescisao = New System.Windows.Forms.Label
        Me.lblAdminissao = New System.Windows.Forms.Label
        Me.txtEmail = New DSTextBox.DSTextBox
        Me.lblEmail = New System.Windows.Forms.Label
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.lblCEP = New System.Windows.Forms.Label
        Me.txtCidade = New DSTextBox.DSTextBox
        Me.lblCidade = New System.Windows.Forms.Label
        Me.txtBairro = New DSTextBox.DSTextBox
        Me.lblBairro = New System.Windows.Forms.Label
        Me.txtNascimento = New System.Windows.Forms.DateTimePicker
        Me.txtComplemento = New DSTextBox.DSTextBox
        Me.lblComplemento = New System.Windows.Forms.Label
        Me.optFeminino = New System.Windows.Forms.RadioButton
        Me.optMasculino = New System.Windows.Forms.RadioButton
        Me.lblSexo = New System.Windows.Forms.Label
        Me.lblDtNascimento = New System.Windows.Forms.Label
        Me.txtNumero = New DSTextBox.DSTextBox
        Me.lblNumero = New System.Windows.Forms.Label
        Me.txtLogradouro = New DSTextBox.DSTextBox
        Me.lblLogradouro = New System.Windows.Forms.Label
        Me.txtNome = New DSTextBox.DSTextBox
        Me.lblEmpresa = New System.Windows.Forms.Label
        Me.tbpFuncoes = New System.Windows.Forms.TabPage
        Me.fraFuncoes = New System.Windows.Forms.GroupBox
        Me.dgvFuncoes = New System.Windows.Forms.DataGridView
        Me.tbpTreinamentos = New System.Windows.Forms.TabPage
        Me.fraTreinamentos = New System.Windows.Forms.GroupBox
        Me.dgvTreinamentos = New System.Windows.Forms.DataGridView
        Me.tbpEPIs = New System.Windows.Forms.TabPage
        Me.fraEPIs = New System.Windows.Forms.GroupBox
        Me.dgvEPIs = New System.Windows.Forms.DataGridView
        Me.tbpDocumentos = New System.Windows.Forms.TabPage
        Me.cmdExportarSelecionados = New System.Windows.Forms.Button
        Me.cmdSelecionarTodos = New System.Windows.Forms.Button
        Me.cmdExcluirDocumento = New System.Windows.Forms.Button
        Me.fraDocumentos = New System.Windows.Forms.GroupBox
        Me.cmdAdicionarDocumentos = New System.Windows.Forms.Button
        Me.dgvDocumentos = New System.Windows.Forms.DataGridView
        Me.lblRegImportado = New System.Windows.Forms.Label
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcFuncionario.SuspendLayout()
        Me.tbpPrincipal.SuspendLayout()
        Me.fraTab1.SuspendLayout()
        Me.fraPrincipal.SuspendLayout()
        Me.grpEmpresa.SuspendLayout()
        Me.tbpFuncoes.SuspendLayout()
        Me.fraFuncoes.SuspendLayout()
        CType(Me.dgvFuncoes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpTreinamentos.SuspendLayout()
        Me.fraTreinamentos.SuspendLayout()
        CType(Me.dgvTreinamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpEPIs.SuspendLayout()
        Me.fraEPIs.SuspendLayout()
        CType(Me.dgvEPIs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDocumentos.SuspendLayout()
        Me.fraDocumentos.SuspendLayout()
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.tbcFuncionario)
        Me.fraGeral.Size = New System.Drawing.Size(543, 409)
        '
        'tbcFuncionario
        '
        Me.tbcFuncionario.Controls.Add(Me.tbpPrincipal)
        Me.tbcFuncionario.Controls.Add(Me.tbpFuncoes)
        Me.tbcFuncionario.Controls.Add(Me.tbpTreinamentos)
        Me.tbcFuncionario.Controls.Add(Me.tbpEPIs)
        Me.tbcFuncionario.Controls.Add(Me.tbpDocumentos)
        Me.tbcFuncionario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcFuncionario.Location = New System.Drawing.Point(3, 16)
        Me.tbcFuncionario.Name = "tbcFuncionario"
        Me.tbcFuncionario.SelectedIndex = 0
        Me.tbcFuncionario.Size = New System.Drawing.Size(537, 390)
        Me.tbcFuncionario.TabIndex = 0
        '
        'tbpPrincipal
        '
        Me.tbpPrincipal.Controls.Add(Me.fraTab1)
        Me.tbpPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tbpPrincipal.Name = "tbpPrincipal"
        Me.tbpPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPrincipal.Size = New System.Drawing.Size(529, 364)
        Me.tbpPrincipal.TabIndex = 1
        Me.tbpPrincipal.Text = "Principal"
        Me.tbpPrincipal.UseVisualStyleBackColor = True
        '
        'fraTab1
        '
        Me.fraTab1.Controls.Add(Me.cmdSelecionarFuncionario)
        Me.fraTab1.Controls.Add(Me.fraPrincipal)
        Me.fraTab1.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraTab1.Location = New System.Drawing.Point(3, 3)
        Me.fraTab1.Name = "fraTab1"
        Me.fraTab1.Size = New System.Drawing.Size(523, 356)
        Me.fraTab1.TabIndex = 0
        Me.fraTab1.TabStop = False
        '
        'cmdSelecionarFuncionario
        '
        Me.cmdSelecionarFuncionario.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncionario.Location = New System.Drawing.Point(470, 14)
        Me.cmdSelecionarFuncionario.Name = "cmdSelecionarFuncionario"
        Me.cmdSelecionarFuncionario.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarFuncionario.TabIndex = 1
        Me.cmdSelecionarFuncionario.UseVisualStyleBackColor = True
        '
        'fraPrincipal
        '
        Me.fraPrincipal.Controls.Add(Me.txtCTPS)
        Me.fraPrincipal.Controls.Add(Me.lblCTPS)
        Me.fraPrincipal.Controls.Add(Me.txtDataEmissao)
        Me.fraPrincipal.Controls.Add(Me.lblDataEmissao)
        Me.fraPrincipal.Controls.Add(Me.txtOrgao)
        Me.fraPrincipal.Controls.Add(Me.lblOrgao)
        Me.fraPrincipal.Controls.Add(Me.txtRG)
        Me.fraPrincipal.Controls.Add(Me.txtCpf)
        Me.fraPrincipal.Controls.Add(Me.lblRG)
        Me.fraPrincipal.Controls.Add(Me.lblRazao)
        Me.fraPrincipal.Controls.Add(Me.txtCelular)
        Me.fraPrincipal.Controls.Add(Me.lblCelular)
        Me.fraPrincipal.Controls.Add(Me.txtTelefone)
        Me.fraPrincipal.Controls.Add(Me.lblTelefone)
        Me.fraPrincipal.Controls.Add(Me.txtCep)
        Me.fraPrincipal.Controls.Add(Me.grpEmpresa)
        Me.fraPrincipal.Controls.Add(Me.txtEmail)
        Me.fraPrincipal.Controls.Add(Me.lblEmail)
        Me.fraPrincipal.Controls.Add(Me.cboEstado)
        Me.fraPrincipal.Controls.Add(Me.lblEstado)
        Me.fraPrincipal.Controls.Add(Me.lblCEP)
        Me.fraPrincipal.Controls.Add(Me.txtCidade)
        Me.fraPrincipal.Controls.Add(Me.lblCidade)
        Me.fraPrincipal.Controls.Add(Me.txtBairro)
        Me.fraPrincipal.Controls.Add(Me.lblBairro)
        Me.fraPrincipal.Controls.Add(Me.txtNascimento)
        Me.fraPrincipal.Controls.Add(Me.txtComplemento)
        Me.fraPrincipal.Controls.Add(Me.lblComplemento)
        Me.fraPrincipal.Controls.Add(Me.optFeminino)
        Me.fraPrincipal.Controls.Add(Me.optMasculino)
        Me.fraPrincipal.Controls.Add(Me.lblSexo)
        Me.fraPrincipal.Controls.Add(Me.lblDtNascimento)
        Me.fraPrincipal.Controls.Add(Me.txtNumero)
        Me.fraPrincipal.Controls.Add(Me.lblNumero)
        Me.fraPrincipal.Controls.Add(Me.txtLogradouro)
        Me.fraPrincipal.Controls.Add(Me.lblLogradouro)
        Me.fraPrincipal.Controls.Add(Me.txtNome)
        Me.fraPrincipal.Controls.Add(Me.lblEmpresa)
        Me.fraPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(522, 356)
        Me.fraPrincipal.TabIndex = 0
        Me.fraPrincipal.TabStop = False
        '
        'txtCTPS
        '
        Me.txtCTPS.Location = New System.Drawing.Point(278, 62)
        Me.txtCTPS.MaxLength = 15
        Me.txtCTPS.Name = "txtCTPS"
        Me.txtCTPS.Size = New System.Drawing.Size(215, 20)
        Me.txtCTPS.TabIndex = 10
        Me.txtCTPS.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblCTPS
        '
        Me.lblCTPS.AutoSize = True
        Me.lblCTPS.Location = New System.Drawing.Point(239, 66)
        Me.lblCTPS.Name = "lblCTPS"
        Me.lblCTPS.Size = New System.Drawing.Size(38, 13)
        Me.lblCTPS.TabIndex = 9
        Me.lblCTPS.Text = "CTPS:"
        '
        'txtDataEmissao
        '
        Me.txtDataEmissao.Checked = False
        Me.txtDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataEmissao.Location = New System.Drawing.Point(393, 85)
        Me.txtDataEmissao.Name = "txtDataEmissao"
        Me.txtDataEmissao.ShowCheckBox = True
        Me.txtDataEmissao.Size = New System.Drawing.Size(100, 20)
        Me.txtDataEmissao.TabIndex = 16
        '
        'lblDataEmissao
        '
        Me.lblDataEmissao.AutoSize = True
        Me.lblDataEmissao.Location = New System.Drawing.Point(360, 88)
        Me.lblDataEmissao.Name = "lblDataEmissao"
        Me.lblDataEmissao.Size = New System.Drawing.Size(33, 13)
        Me.lblDataEmissao.TabIndex = 15
        Me.lblDataEmissao.Text = "Data:"
        '
        'txtOrgao
        '
        Me.txtOrgao.Location = New System.Drawing.Point(278, 85)
        Me.txtOrgao.MaxLength = 6
        Me.txtOrgao.Name = "txtOrgao"
        Me.txtOrgao.Size = New System.Drawing.Size(79, 20)
        Me.txtOrgao.TabIndex = 14
        Me.txtOrgao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblOrgao
        '
        Me.lblOrgao.AutoSize = True
        Me.lblOrgao.Location = New System.Drawing.Point(239, 89)
        Me.lblOrgao.Name = "lblOrgao"
        Me.lblOrgao.Size = New System.Drawing.Size(39, 13)
        Me.lblOrgao.TabIndex = 13
        Me.lblOrgao.Text = "Órgão:"
        '
        'txtRG
        '
        Me.txtRG.Location = New System.Drawing.Point(76, 86)
        Me.txtRG.MaxLength = 15
        Me.txtRG.Name = "txtRG"
        Me.txtRG.Size = New System.Drawing.Size(148, 20)
        Me.txtRG.TabIndex = 12
        Me.txtRG.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtCpf
        '
        Me.txtCpf.Location = New System.Drawing.Point(76, 62)
        Me.txtCpf.Mask = "###.###.###-##"
        Me.txtCpf.Name = "txtCpf"
        Me.txtCpf.Size = New System.Drawing.Size(149, 20)
        Me.txtCpf.TabIndex = 8
        '
        'lblRG
        '
        Me.lblRG.AutoSize = True
        Me.lblRG.Location = New System.Drawing.Point(45, 89)
        Me.lblRG.Name = "lblRG"
        Me.lblRG.Size = New System.Drawing.Size(26, 13)
        Me.lblRG.TabIndex = 11
        Me.lblRG.Text = "RG:"
        '
        'lblRazao
        '
        Me.lblRazao.AutoSize = True
        Me.lblRazao.Location = New System.Drawing.Point(39, 67)
        Me.lblRazao.Name = "lblRazao"
        Me.lblRazao.Size = New System.Drawing.Size(30, 13)
        Me.lblRazao.TabIndex = 7
        Me.lblRazao.Text = "CPF:"
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(240, 226)
        Me.txtCelular.Mask = "(###)####-####"
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(100, 20)
        Me.txtCelular.TabIndex = 36
        '
        'lblCelular
        '
        Me.lblCelular.AutoSize = True
        Me.lblCelular.Location = New System.Drawing.Point(183, 230)
        Me.lblCelular.Name = "lblCelular"
        Me.lblCelular.Size = New System.Drawing.Size(42, 13)
        Me.lblCelular.TabIndex = 35
        Me.lblCelular.Text = "Celular:"
        '
        'txtTelefone
        '
        Me.txtTelefone.Location = New System.Drawing.Point(76, 227)
        Me.txtTelefone.Mask = "(###)####-####"
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefone.TabIndex = 34
        '
        'lblTelefone
        '
        Me.lblTelefone.AutoSize = True
        Me.lblTelefone.Location = New System.Drawing.Point(19, 231)
        Me.lblTelefone.Name = "lblTelefone"
        Me.lblTelefone.Size = New System.Drawing.Size(52, 13)
        Me.lblTelefone.TabIndex = 33
        Me.lblTelefone.Text = "Telefone:"
        '
        'txtCep
        '
        Me.txtCep.Location = New System.Drawing.Point(402, 156)
        Me.txtCep.Mask = "##.###-###"
        Me.txtCep.Name = "txtCep"
        Me.txtCep.Size = New System.Drawing.Size(91, 20)
        Me.txtCep.TabIndex = 26
        '
        'grpEmpresa
        '
        Me.grpEmpresa.Controls.Add(Me.lblRegImportado)
        Me.grpEmpresa.Controls.Add(Me.cmdSelecionarFuncao)
        Me.grpEmpresa.Controls.Add(Me.txtAdmissao)
        Me.grpEmpresa.Controls.Add(Me.txtRescisao)
        Me.grpEmpresa.Controls.Add(Me.txtRegistro)
        Me.grpEmpresa.Controls.Add(Me.lblRegistro)
        Me.grpEmpresa.Controls.Add(Me.cmdLimparFuncao)
        Me.grpEmpresa.Controls.Add(Me.txtFuncao)
        Me.grpEmpresa.Controls.Add(Me.lblFuncao)
        Me.grpEmpresa.Controls.Add(Me.lblRescisao)
        Me.grpEmpresa.Controls.Add(Me.lblAdminissao)
        Me.grpEmpresa.Location = New System.Drawing.Point(8, 250)
        Me.grpEmpresa.Name = "grpEmpresa"
        Me.grpEmpresa.Size = New System.Drawing.Size(506, 98)
        Me.grpEmpresa.TabIndex = 37
        Me.grpEmpresa.TabStop = False
        Me.grpEmpresa.Text = "Dados Empresa"
        '
        'cmdSelecionarFuncao
        '
        Me.cmdSelecionarFuncao.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncao.Location = New System.Drawing.Point(440, 68)
        Me.cmdSelecionarFuncao.Name = "cmdSelecionarFuncao"
        Me.cmdSelecionarFuncao.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarFuncao.TabIndex = 8
        Me.cmdSelecionarFuncao.UseVisualStyleBackColor = True
        '
        'txtAdmissao
        '
        Me.txtAdmissao.Checked = False
        Me.txtAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtAdmissao.Location = New System.Drawing.Point(63, 46)
        Me.txtAdmissao.Name = "txtAdmissao"
        Me.txtAdmissao.Size = New System.Drawing.Size(100, 20)
        Me.txtAdmissao.TabIndex = 3
        '
        'txtRescisao
        '
        Me.txtRescisao.Checked = False
        Me.txtRescisao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtRescisao.Location = New System.Drawing.Point(385, 46)
        Me.txtRescisao.Name = "txtRescisao"
        Me.txtRescisao.ShowCheckBox = True
        Me.txtRescisao.Size = New System.Drawing.Size(100, 20)
        Me.txtRescisao.TabIndex = 5
        '
        'txtRegistro
        '
        Me.txtRegistro.Location = New System.Drawing.Point(63, 22)
        Me.txtRegistro.MaxLength = 15
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.Size = New System.Drawing.Size(98, 20)
        Me.txtRegistro.TabIndex = 1
        Me.txtRegistro.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblRegistro
        '
        Me.lblRegistro.AutoSize = True
        Me.lblRegistro.Location = New System.Drawing.Point(8, 26)
        Me.lblRegistro.Name = "lblRegistro"
        Me.lblRegistro.Size = New System.Drawing.Size(49, 13)
        Me.lblRegistro.TabIndex = 0
        Me.lblRegistro.Text = "Registro:"
        '
        'cmdLimparFuncao
        '
        Me.cmdLimparFuncao.Image = Global.Fronteira.My.Resources.Resources.Limpar
        Me.cmdLimparFuncao.Location = New System.Drawing.Point(463, 68)
        Me.cmdLimparFuncao.Name = "cmdLimparFuncao"
        Me.cmdLimparFuncao.Size = New System.Drawing.Size(22, 23)
        Me.cmdLimparFuncao.TabIndex = 9
        Me.cmdLimparFuncao.UseVisualStyleBackColor = True
        '
        'txtFuncao
        '
        Me.txtFuncao.Location = New System.Drawing.Point(63, 69)
        Me.txtFuncao.Name = "txtFuncao"
        Me.txtFuncao.ReadOnly = True
        Me.txtFuncao.Size = New System.Drawing.Size(374, 20)
        Me.txtFuncao.TabIndex = 7
        Me.txtFuncao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblFuncao
        '
        Me.lblFuncao.AutoSize = True
        Me.lblFuncao.Location = New System.Drawing.Point(11, 72)
        Me.lblFuncao.Name = "lblFuncao"
        Me.lblFuncao.Size = New System.Drawing.Size(46, 13)
        Me.lblFuncao.TabIndex = 6
        Me.lblFuncao.Text = "Função:"
        '
        'lblRescisao
        '
        Me.lblRescisao.AutoSize = True
        Me.lblRescisao.Location = New System.Drawing.Point(327, 49)
        Me.lblRescisao.Name = "lblRescisao"
        Me.lblRescisao.Size = New System.Drawing.Size(54, 13)
        Me.lblRescisao.TabIndex = 4
        Me.lblRescisao.Text = "Rescisão:"
        Me.lblRescisao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAdminissao
        '
        Me.lblAdminissao.AutoSize = True
        Me.lblAdminissao.Location = New System.Drawing.Point(2, 49)
        Me.lblAdminissao.Name = "lblAdminissao"
        Me.lblAdminissao.Size = New System.Drawing.Size(55, 13)
        Me.lblAdminissao.TabIndex = 2
        Me.lblAdminissao.Text = "Admissão:"
        Me.lblAdminissao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(76, 203)
        Me.txtEmail.MaxLength = 30
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(417, 20)
        Me.txtEmail.TabIndex = 32
        Me.txtEmail.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(33, 207)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(38, 13)
        Me.lblEmail.TabIndex = 31
        Me.lblEmail.Text = "E-mail:"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(410, 179)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(83, 21)
        Me.cboEstado.TabIndex = 30
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(362, 183)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblEstado.TabIndex = 29
        Me.lblEstado.Text = "Estado:"
        '
        'lblCEP
        '
        Me.lblCEP.AutoSize = True
        Me.lblCEP.Location = New System.Drawing.Point(356, 160)
        Me.lblCEP.Name = "lblCEP"
        Me.lblCEP.Size = New System.Drawing.Size(31, 13)
        Me.lblCEP.TabIndex = 25
        Me.lblCEP.Text = "CEP:"
        '
        'txtCidade
        '
        Me.txtCidade.Location = New System.Drawing.Point(76, 180)
        Me.txtCidade.MaxLength = 30
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(275, 20)
        Me.txtCidade.TabIndex = 28
        Me.txtCidade.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblCidade
        '
        Me.lblCidade.AutoSize = True
        Me.lblCidade.Location = New System.Drawing.Point(28, 184)
        Me.lblCidade.Name = "lblCidade"
        Me.lblCidade.Size = New System.Drawing.Size(43, 13)
        Me.lblCidade.TabIndex = 27
        Me.lblCidade.Text = "Cidade:"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(76, 156)
        Me.txtBairro.MaxLength = 30
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(274, 20)
        Me.txtBairro.TabIndex = 24
        Me.txtBairro.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblBairro
        '
        Me.lblBairro.AutoSize = True
        Me.lblBairro.Location = New System.Drawing.Point(33, 160)
        Me.lblBairro.Name = "lblBairro"
        Me.lblBairro.Size = New System.Drawing.Size(37, 13)
        Me.lblBairro.TabIndex = 23
        Me.lblBairro.Text = "Bairro:"
        '
        'txtNascimento
        '
        Me.txtNascimento.Checked = False
        Me.txtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtNascimento.Location = New System.Drawing.Point(76, 39)
        Me.txtNascimento.Name = "txtNascimento"
        Me.txtNascimento.Size = New System.Drawing.Size(100, 20)
        Me.txtNascimento.TabIndex = 3
        '
        'txtComplemento
        '
        Me.txtComplemento.Location = New System.Drawing.Point(278, 133)
        Me.txtComplemento.MaxLength = 15
        Me.txtComplemento.Name = "txtComplemento"
        Me.txtComplemento.Size = New System.Drawing.Size(215, 20)
        Me.txtComplemento.TabIndex = 22
        Me.txtComplemento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblComplemento
        '
        Me.lblComplemento.AutoSize = True
        Me.lblComplemento.Location = New System.Drawing.Point(198, 137)
        Me.lblComplemento.Name = "lblComplemento"
        Me.lblComplemento.Size = New System.Drawing.Size(74, 13)
        Me.lblComplemento.TabIndex = 21
        Me.lblComplemento.Text = "Complemento:"
        '
        'optFeminino
        '
        Me.optFeminino.AutoSize = True
        Me.optFeminino.Location = New System.Drawing.Point(275, 41)
        Me.optFeminino.Name = "optFeminino"
        Me.optFeminino.Size = New System.Drawing.Size(67, 17)
        Me.optFeminino.TabIndex = 5
        Me.optFeminino.Text = "Feminino"
        Me.optFeminino.UseVisualStyleBackColor = True
        '
        'optMasculino
        '
        Me.optMasculino.AutoSize = True
        Me.optMasculino.Checked = True
        Me.optMasculino.Location = New System.Drawing.Point(348, 41)
        Me.optMasculino.Name = "optMasculino"
        Me.optMasculino.Size = New System.Drawing.Size(73, 17)
        Me.optMasculino.TabIndex = 6
        Me.optMasculino.TabStop = True
        Me.optMasculino.Text = "Masculino"
        Me.optMasculino.UseVisualStyleBackColor = True
        '
        'lblSexo
        '
        Me.lblSexo.AutoSize = True
        Me.lblSexo.Location = New System.Drawing.Point(235, 43)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(34, 13)
        Me.lblSexo.TabIndex = 4
        Me.lblSexo.Text = "Sexo:"
        '
        'lblDtNascimento
        '
        Me.lblDtNascimento.AutoSize = True
        Me.lblDtNascimento.Location = New System.Drawing.Point(5, 43)
        Me.lblDtNascimento.Name = "lblDtNascimento"
        Me.lblDtNascimento.Size = New System.Drawing.Size(66, 13)
        Me.lblDtNascimento.TabIndex = 2
        Me.lblDtNascimento.Text = "Nascimento:"
        Me.lblDtNascimento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(76, 133)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 20
        Me.txtNumero.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(24, 137)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(47, 13)
        Me.lblNumero.TabIndex = 19
        Me.lblNumero.Text = "Número:"
        '
        'txtLogradouro
        '
        Me.txtLogradouro.Location = New System.Drawing.Point(76, 110)
        Me.txtLogradouro.MaxLength = 30
        Me.txtLogradouro.Name = "txtLogradouro"
        Me.txtLogradouro.Size = New System.Drawing.Size(417, 20)
        Me.txtLogradouro.TabIndex = 18
        Me.txtLogradouro.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblLogradouro
        '
        Me.lblLogradouro.AutoSize = True
        Me.lblLogradouro.Location = New System.Drawing.Point(7, 114)
        Me.lblLogradouro.Name = "lblLogradouro"
        Me.lblLogradouro.Size = New System.Drawing.Size(64, 13)
        Me.lblLogradouro.TabIndex = 17
        Me.lblLogradouro.Text = "Logradouro:"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(75, 16)
        Me.txtNome.MaxLength = 50
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(392, 20)
        Me.txtNome.TabIndex = 1
        Me.txtNome.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(32, 20)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(38, 13)
        Me.lblEmpresa.TabIndex = 0
        Me.lblEmpresa.Text = "Nome:"
        '
        'tbpFuncoes
        '
        Me.tbpFuncoes.Controls.Add(Me.fraFuncoes)
        Me.tbpFuncoes.Location = New System.Drawing.Point(4, 22)
        Me.tbpFuncoes.Name = "tbpFuncoes"
        Me.tbpFuncoes.Size = New System.Drawing.Size(529, 364)
        Me.tbpFuncoes.TabIndex = 2
        Me.tbpFuncoes.Text = "Funções"
        Me.tbpFuncoes.UseVisualStyleBackColor = True
        '
        'fraFuncoes
        '
        Me.fraFuncoes.Controls.Add(Me.dgvFuncoes)
        Me.fraFuncoes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraFuncoes.Location = New System.Drawing.Point(0, 0)
        Me.fraFuncoes.Name = "fraFuncoes"
        Me.fraFuncoes.Size = New System.Drawing.Size(529, 364)
        Me.fraFuncoes.TabIndex = 0
        Me.fraFuncoes.TabStop = False
        '
        'dgvFuncoes
        '
        Me.dgvFuncoes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvFuncoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuncoes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFuncoes.Location = New System.Drawing.Point(3, 16)
        Me.dgvFuncoes.Name = "dgvFuncoes"
        Me.dgvFuncoes.Size = New System.Drawing.Size(523, 345)
        Me.dgvFuncoes.TabIndex = 0
        '
        'tbpTreinamentos
        '
        Me.tbpTreinamentos.Controls.Add(Me.fraTreinamentos)
        Me.tbpTreinamentos.Location = New System.Drawing.Point(4, 22)
        Me.tbpTreinamentos.Name = "tbpTreinamentos"
        Me.tbpTreinamentos.Size = New System.Drawing.Size(529, 364)
        Me.tbpTreinamentos.TabIndex = 3
        Me.tbpTreinamentos.Text = "Treinamentos"
        Me.tbpTreinamentos.UseVisualStyleBackColor = True
        '
        'fraTreinamentos
        '
        Me.fraTreinamentos.Controls.Add(Me.dgvTreinamentos)
        Me.fraTreinamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraTreinamentos.Location = New System.Drawing.Point(0, 0)
        Me.fraTreinamentos.Name = "fraTreinamentos"
        Me.fraTreinamentos.Size = New System.Drawing.Size(529, 364)
        Me.fraTreinamentos.TabIndex = 1
        Me.fraTreinamentos.TabStop = False
        '
        'dgvTreinamentos
        '
        Me.dgvTreinamentos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvTreinamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTreinamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTreinamentos.Location = New System.Drawing.Point(3, 16)
        Me.dgvTreinamentos.Name = "dgvTreinamentos"
        Me.dgvTreinamentos.Size = New System.Drawing.Size(523, 345)
        Me.dgvTreinamentos.TabIndex = 0
        '
        'tbpEPIs
        '
        Me.tbpEPIs.Controls.Add(Me.fraEPIs)
        Me.tbpEPIs.Location = New System.Drawing.Point(4, 22)
        Me.tbpEPIs.Name = "tbpEPIs"
        Me.tbpEPIs.Size = New System.Drawing.Size(529, 364)
        Me.tbpEPIs.TabIndex = 4
        Me.tbpEPIs.Text = "EPIs"
        Me.tbpEPIs.UseVisualStyleBackColor = True
        '
        'fraEPIs
        '
        Me.fraEPIs.Controls.Add(Me.dgvEPIs)
        Me.fraEPIs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraEPIs.Location = New System.Drawing.Point(0, 0)
        Me.fraEPIs.Name = "fraEPIs"
        Me.fraEPIs.Size = New System.Drawing.Size(529, 364)
        Me.fraEPIs.TabIndex = 1
        Me.fraEPIs.TabStop = False
        '
        'dgvEPIs
        '
        Me.dgvEPIs.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvEPIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEPIs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEPIs.Location = New System.Drawing.Point(3, 16)
        Me.dgvEPIs.Name = "dgvEPIs"
        Me.dgvEPIs.Size = New System.Drawing.Size(523, 345)
        Me.dgvEPIs.TabIndex = 0
        '
        'tbpDocumentos
        '
        Me.tbpDocumentos.Controls.Add(Me.cmdExportarSelecionados)
        Me.tbpDocumentos.Controls.Add(Me.cmdSelecionarTodos)
        Me.tbpDocumentos.Controls.Add(Me.cmdExcluirDocumento)
        Me.tbpDocumentos.Controls.Add(Me.fraDocumentos)
        Me.tbpDocumentos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDocumentos.Name = "tbpDocumentos"
        Me.tbpDocumentos.Size = New System.Drawing.Size(529, 364)
        Me.tbpDocumentos.TabIndex = 5
        Me.tbpDocumentos.Text = "Documentos"
        Me.tbpDocumentos.UseVisualStyleBackColor = True
        '
        'cmdExportarSelecionados
        '
        Me.cmdExportarSelecionados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExportarSelecionados.Location = New System.Drawing.Point(404, 331)
        Me.cmdExportarSelecionados.Name = "cmdExportarSelecionados"
        Me.cmdExportarSelecionados.Size = New System.Drawing.Size(120, 27)
        Me.cmdExportarSelecionados.TabIndex = 50
        Me.cmdExportarSelecionados.Text = "Exportar selecionados"
        Me.cmdExportarSelecionados.UseVisualStyleBackColor = True
        '
        'cmdSelecionarTodos
        '
        Me.cmdSelecionarTodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelecionarTodos.Location = New System.Drawing.Point(306, 331)
        Me.cmdSelecionarTodos.Name = "cmdSelecionarTodos"
        Me.cmdSelecionarTodos.Size = New System.Drawing.Size(96, 27)
        Me.cmdSelecionarTodos.TabIndex = 49
        Me.cmdSelecionarTodos.Text = "Selecionar todos"
        Me.cmdSelecionarTodos.UseVisualStyleBackColor = True
        '
        'cmdExcluirDocumento
        '
        Me.cmdExcluirDocumento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcluirDocumento.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirDocumento.Location = New System.Drawing.Point(497, 1)
        Me.cmdExcluirDocumento.Name = "cmdExcluirDocumento"
        Me.cmdExcluirDocumento.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirDocumento.TabIndex = 48
        Me.cmdExcluirDocumento.Tag = ""
        Me.cmdExcluirDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirDocumento.UseVisualStyleBackColor = False
        '
        'fraDocumentos
        '
        Me.fraDocumentos.Controls.Add(Me.cmdAdicionarDocumentos)
        Me.fraDocumentos.Controls.Add(Me.dgvDocumentos)
        Me.fraDocumentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraDocumentos.Location = New System.Drawing.Point(0, 0)
        Me.fraDocumentos.Name = "fraDocumentos"
        Me.fraDocumentos.Size = New System.Drawing.Size(529, 364)
        Me.fraDocumentos.TabIndex = 4
        Me.fraDocumentos.TabStop = False
        '
        'cmdAdicionarDocumentos
        '
        Me.cmdAdicionarDocumentos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarDocumentos.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdicionarDocumentos.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarDocumentos.Location = New System.Drawing.Point(475, 1)
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
        Me.dgvDocumentos.Location = New System.Drawing.Point(3, 22)
        Me.dgvDocumentos.Name = "dgvDocumentos"
        Me.dgvDocumentos.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvDocumentos.Size = New System.Drawing.Size(523, 304)
        Me.dgvDocumentos.TabIndex = 43
        '
        'lblRegImportado
        '
        Me.lblRegImportado.AutoSize = True
        Me.lblRegImportado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegImportado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRegImportado.Location = New System.Drawing.Point(371, 16)
        Me.lblRegImportado.Name = "lblRegImportado"
        Me.lblRegImportado.Size = New System.Drawing.Size(114, 13)
        Me.lblRegImportado.TabIndex = 11
        Me.lblRegImportado.Text = "Registro Importado"
        Me.lblRegImportado.Visible = False
        '
        'frmFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 409)
        Me.Name = "frmFuncionario"
        Me.Text = "Cadastro de Funcionário"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcFuncionario.ResumeLayout(False)
        Me.tbpPrincipal.ResumeLayout(False)
        Me.fraTab1.ResumeLayout(False)
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.grpEmpresa.ResumeLayout(False)
        Me.grpEmpresa.PerformLayout()
        Me.tbpFuncoes.ResumeLayout(False)
        Me.fraFuncoes.ResumeLayout(False)
        CType(Me.dgvFuncoes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpTreinamentos.ResumeLayout(False)
        Me.fraTreinamentos.ResumeLayout(False)
        CType(Me.dgvTreinamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpEPIs.ResumeLayout(False)
        Me.fraEPIs.ResumeLayout(False)
        CType(Me.dgvEPIs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDocumentos.ResumeLayout(False)
        Me.fraDocumentos.ResumeLayout(False)
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcFuncionario As System.Windows.Forms.TabControl
    Friend WithEvents tbpPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents fraTab1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelecionarFuncionario As System.Windows.Forms.Button
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents txtCelular As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCelular As System.Windows.Forms.Label
    Friend WithEvents txtTelefone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblTelefone As System.Windows.Forms.Label
    Friend WithEvents txtCep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelecionarFuncao As System.Windows.Forms.Button
    Friend WithEvents txtAdmissao As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRescisao As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRegistro As DSTextBox.DSTextBox
    Friend WithEvents lblRegistro As System.Windows.Forms.Label
    Friend WithEvents cmdLimparFuncao As System.Windows.Forms.Button
    Friend WithEvents txtFuncao As DSTextBox.DSTextBox
    Friend WithEvents lblFuncao As System.Windows.Forms.Label
    Friend WithEvents lblRescisao As System.Windows.Forms.Label
    Friend WithEvents lblAdminissao As System.Windows.Forms.Label
    Friend WithEvents txtEmail As DSTextBox.DSTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblCEP As System.Windows.Forms.Label
    Friend WithEvents txtCidade As DSTextBox.DSTextBox
    Friend WithEvents lblCidade As System.Windows.Forms.Label
    Friend WithEvents txtBairro As DSTextBox.DSTextBox
    Friend WithEvents lblBairro As System.Windows.Forms.Label
    Friend WithEvents txtNascimento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComplemento As DSTextBox.DSTextBox
    Friend WithEvents lblComplemento As System.Windows.Forms.Label
    Friend WithEvents optFeminino As System.Windows.Forms.RadioButton
    Friend WithEvents optMasculino As System.Windows.Forms.RadioButton
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents lblDtNascimento As System.Windows.Forms.Label
    Friend WithEvents txtNumero As DSTextBox.DSTextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtLogradouro As DSTextBox.DSTextBox
    Friend WithEvents lblLogradouro As System.Windows.Forms.Label
    Friend WithEvents txtNome As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents txtCpf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblRG As System.Windows.Forms.Label
    Friend WithEvents lblRazao As System.Windows.Forms.Label
    Friend WithEvents txtDataEmissao As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDataEmissao As System.Windows.Forms.Label
    Friend WithEvents txtOrgao As DSTextBox.DSTextBox
    Friend WithEvents lblOrgao As System.Windows.Forms.Label
    Friend WithEvents txtRG As DSTextBox.DSTextBox
    Friend WithEvents txtCTPS As DSTextBox.DSTextBox
    Friend WithEvents lblCTPS As System.Windows.Forms.Label
    Friend WithEvents tbpFuncoes As System.Windows.Forms.TabPage
    Friend WithEvents fraFuncoes As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFuncoes As System.Windows.Forms.DataGridView
    Friend WithEvents tbpTreinamentos As System.Windows.Forms.TabPage
    Friend WithEvents fraTreinamentos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTreinamentos As System.Windows.Forms.DataGridView
    Friend WithEvents tbpEPIs As System.Windows.Forms.TabPage
    Friend WithEvents fraEPIs As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEPIs As System.Windows.Forms.DataGridView
    Friend WithEvents tbpDocumentos As System.Windows.Forms.TabPage
    Friend WithEvents fraDocumentos As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdAdicionarDocumentos As System.Windows.Forms.Button
    Friend WithEvents dgvDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportarSelecionados As System.Windows.Forms.Button
    Friend WithEvents cmdSelecionarTodos As System.Windows.Forms.Button
    Protected Friend WithEvents cmdExcluirDocumento As System.Windows.Forms.Button
    Friend WithEvents lblRegImportado As System.Windows.Forms.Label
End Class
