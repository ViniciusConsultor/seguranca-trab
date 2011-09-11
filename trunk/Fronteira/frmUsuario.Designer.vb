<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Me.tbcUsuario = New System.Windows.Forms.TabControl
        Me.tbpUsuario = New System.Windows.Forms.TabPage
        Me.fraUsuario = New System.Windows.Forms.GroupBox
        Me.cmdSelecionarGrupoAcesso = New System.Windows.Forms.Button
        Me.txtGrupoAcesso = New DSTextBox.DSTextBox
        Me.lblGrupoAcesso = New System.Windows.Forms.Label
        Me.txtSenha = New DSTextBox.DSTextBox
        Me.lblSenha = New System.Windows.Forms.Label
        Me.txtLogin = New DSTextBox.DSTextBox
        Me.lblLogin = New System.Windows.Forms.Label
        Me.txtNome = New DSTextBox.DSTextBox
        Me.lblNome = New System.Windows.Forms.Label
        Me.tbpEmpresas = New System.Windows.Forms.TabPage
        Me.fraAcessoEmpresas = New System.Windows.Forms.GroupBox
        Me.dgvAcessoEmpresas = New System.Windows.Forms.DataGridView
        Me.cmdSelecionarUsuario = New System.Windows.Forms.Button
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcUsuario.SuspendLayout()
        Me.tbpUsuario.SuspendLayout()
        Me.fraUsuario.SuspendLayout()
        Me.tbpEmpresas.SuspendLayout()
        Me.fraAcessoEmpresas.SuspendLayout()
        CType(Me.dgvAcessoEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.tbcUsuario)
        Me.fraGeral.Size = New System.Drawing.Size(392, 180)
        '
        'tbcUsuario
        '
        Me.tbcUsuario.Controls.Add(Me.tbpUsuario)
        Me.tbcUsuario.Controls.Add(Me.tbpEmpresas)
        Me.tbcUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcUsuario.Location = New System.Drawing.Point(3, 16)
        Me.tbcUsuario.Name = "tbcUsuario"
        Me.tbcUsuario.SelectedIndex = 0
        Me.tbcUsuario.Size = New System.Drawing.Size(386, 161)
        Me.tbcUsuario.TabIndex = 1
        '
        'tbpUsuario
        '
        Me.tbpUsuario.Controls.Add(Me.cmdSelecionarUsuario)
        Me.tbpUsuario.Controls.Add(Me.fraUsuario)
        Me.tbpUsuario.Location = New System.Drawing.Point(4, 22)
        Me.tbpUsuario.Name = "tbpUsuario"
        Me.tbpUsuario.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpUsuario.Size = New System.Drawing.Size(378, 135)
        Me.tbpUsuario.TabIndex = 1
        Me.tbpUsuario.Text = "Usuário"
        Me.tbpUsuario.UseVisualStyleBackColor = True
        '
        'fraUsuario
        '
        Me.fraUsuario.Controls.Add(Me.cmdSelecionarGrupoAcesso)
        Me.fraUsuario.Controls.Add(Me.txtGrupoAcesso)
        Me.fraUsuario.Controls.Add(Me.lblGrupoAcesso)
        Me.fraUsuario.Controls.Add(Me.txtSenha)
        Me.fraUsuario.Controls.Add(Me.lblSenha)
        Me.fraUsuario.Controls.Add(Me.txtLogin)
        Me.fraUsuario.Controls.Add(Me.lblLogin)
        Me.fraUsuario.Controls.Add(Me.txtNome)
        Me.fraUsuario.Controls.Add(Me.lblNome)
        Me.fraUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraUsuario.Location = New System.Drawing.Point(3, 3)
        Me.fraUsuario.Name = "fraUsuario"
        Me.fraUsuario.Size = New System.Drawing.Size(372, 129)
        Me.fraUsuario.TabIndex = 0
        Me.fraUsuario.TabStop = False
        '
        'cmdSelecionarGrupoAcesso
        '
        Me.cmdSelecionarGrupoAcesso.Image = CType(resources.GetObject("cmdSelecionarGrupoAcesso.Image"), System.Drawing.Image)
        Me.cmdSelecionarGrupoAcesso.Location = New System.Drawing.Point(327, 92)
        Me.cmdSelecionarGrupoAcesso.Name = "cmdSelecionarGrupoAcesso"
        Me.cmdSelecionarGrupoAcesso.Size = New System.Drawing.Size(22, 21)
        Me.cmdSelecionarGrupoAcesso.TabIndex = 77
        Me.cmdSelecionarGrupoAcesso.UseVisualStyleBackColor = True
        '
        'txtGrupoAcesso
        '
        Me.txtGrupoAcesso.Location = New System.Drawing.Point(90, 93)
        Me.txtGrupoAcesso.Name = "txtGrupoAcesso"
        Me.txtGrupoAcesso.Size = New System.Drawing.Size(232, 20)
        Me.txtGrupoAcesso.TabIndex = 75
        Me.txtGrupoAcesso.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblGrupoAcesso
        '
        Me.lblGrupoAcesso.AutoSize = True
        Me.lblGrupoAcesso.Location = New System.Drawing.Point(11, 95)
        Me.lblGrupoAcesso.Name = "lblGrupoAcesso"
        Me.lblGrupoAcesso.Size = New System.Drawing.Size(76, 13)
        Me.lblGrupoAcesso.TabIndex = 76
        Me.lblGrupoAcesso.Text = "Grupo acesso:"
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(90, 67)
        Me.txtSenha.MaxLength = 30
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(232, 20)
        Me.txtSenha.TabIndex = 73
        Me.txtSenha.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblSenha
        '
        Me.lblSenha.AutoSize = True
        Me.lblSenha.Location = New System.Drawing.Point(46, 69)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(41, 13)
        Me.lblSenha.TabIndex = 74
        Me.lblSenha.Text = "Senha:"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(90, 41)
        Me.txtLogin.MaxLength = 30
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(232, 20)
        Me.txtLogin.TabIndex = 71
        Me.txtLogin.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(51, 43)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(36, 13)
        Me.lblLogin.TabIndex = 72
        Me.lblLogin.Text = "Login:"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(90, 15)
        Me.txtNome.MaxLength = 30
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(232, 20)
        Me.txtNome.TabIndex = 69
        Me.txtNome.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.Location = New System.Drawing.Point(49, 17)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(38, 13)
        Me.lblNome.TabIndex = 70
        Me.lblNome.Text = "Nome:"
        '
        'tbpEmpresas
        '
        Me.tbpEmpresas.Controls.Add(Me.fraAcessoEmpresas)
        Me.tbpEmpresas.Location = New System.Drawing.Point(4, 22)
        Me.tbpEmpresas.Name = "tbpEmpresas"
        Me.tbpEmpresas.Size = New System.Drawing.Size(378, 135)
        Me.tbpEmpresas.TabIndex = 2
        Me.tbpEmpresas.Text = "Empresas"
        Me.tbpEmpresas.UseVisualStyleBackColor = True
        '
        'fraAcessoEmpresas
        '
        Me.fraAcessoEmpresas.Controls.Add(Me.dgvAcessoEmpresas)
        Me.fraAcessoEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraAcessoEmpresas.Location = New System.Drawing.Point(0, 0)
        Me.fraAcessoEmpresas.Name = "fraAcessoEmpresas"
        Me.fraAcessoEmpresas.Size = New System.Drawing.Size(378, 135)
        Me.fraAcessoEmpresas.TabIndex = 1
        Me.fraAcessoEmpresas.TabStop = False
        '
        'dgvAcessoEmpresas
        '
        Me.dgvAcessoEmpresas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvAcessoEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAcessoEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAcessoEmpresas.Location = New System.Drawing.Point(3, 16)
        Me.dgvAcessoEmpresas.Name = "dgvAcessoEmpresas"
        Me.dgvAcessoEmpresas.Size = New System.Drawing.Size(372, 116)
        Me.dgvAcessoEmpresas.TabIndex = 0
        '
        'cmdSelecionarUsuario
        '
        Me.cmdSelecionarUsuario.Image = CType(resources.GetObject("cmdSelecionarUsuario.Image"), System.Drawing.Image)
        Me.cmdSelecionarUsuario.Location = New System.Drawing.Point(329, 16)
        Me.cmdSelecionarUsuario.Name = "cmdSelecionarUsuario"
        Me.cmdSelecionarUsuario.Size = New System.Drawing.Size(22, 21)
        Me.cmdSelecionarUsuario.TabIndex = 81
        Me.cmdSelecionarUsuario.UseVisualStyleBackColor = True
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 180)
        Me.Name = "frmUsuario"
        Me.Text = "Cadastro de Usuário"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcUsuario.ResumeLayout(False)
        Me.tbpUsuario.ResumeLayout(False)
        Me.fraUsuario.ResumeLayout(False)
        Me.fraUsuario.PerformLayout()
        Me.tbpEmpresas.ResumeLayout(False)
        Me.fraAcessoEmpresas.ResumeLayout(False)
        CType(Me.dgvAcessoEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcUsuario As System.Windows.Forms.TabControl
    Friend WithEvents tbpUsuario As System.Windows.Forms.TabPage
    Friend WithEvents fraUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelecionarGrupoAcesso As System.Windows.Forms.Button
    Friend WithEvents txtGrupoAcesso As DSTextBox.DSTextBox
    Friend WithEvents lblGrupoAcesso As System.Windows.Forms.Label
    Friend WithEvents txtSenha As DSTextBox.DSTextBox
    Friend WithEvents lblSenha As System.Windows.Forms.Label
    Friend WithEvents txtLogin As DSTextBox.DSTextBox
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents txtNome As DSTextBox.DSTextBox
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents tbpEmpresas As System.Windows.Forms.TabPage
    Friend WithEvents fraAcessoEmpresas As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAcessoEmpresas As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSelecionarUsuario As System.Windows.Forms.Button
End Class
