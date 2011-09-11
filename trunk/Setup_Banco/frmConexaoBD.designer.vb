<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexaoBD
    Inherits System.Windows.Forms.Form

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
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.txtSenha = New DSTextBox.DSTextBox
        Me.txtLogin = New DSTextBox.DSTextBox
        Me.txtServidor = New DSTextBox.DSTextBox
        Me.fraComandos = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdTestarConexao = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblSenha = New System.Windows.Forms.Label
        Me.lblLogin = New System.Windows.Forms.Label
        Me.lblServidor = New System.Windows.Forms.Label
        Me.fraGeral.SuspendLayout()
        Me.fraComandos.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.txtSenha)
        Me.fraGeral.Controls.Add(Me.txtLogin)
        Me.fraGeral.Controls.Add(Me.txtServidor)
        Me.fraGeral.Controls.Add(Me.fraComandos)
        Me.fraGeral.Controls.Add(Me.lblSenha)
        Me.fraGeral.Controls.Add(Me.lblLogin)
        Me.fraGeral.Controls.Add(Me.lblServidor)
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(353, 139)
        Me.fraGeral.TabIndex = 6
        Me.fraGeral.TabStop = False
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(105, 63)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(236, 20)
        Me.txtSenha.TabIndex = 24
        Me.txtSenha.Text = "sasenha"
        Me.txtSenha.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(105, 40)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtLogin.Size = New System.Drawing.Size(236, 20)
        Me.txtLogin.TabIndex = 23
        Me.txtLogin.Text = "sa"
        Me.txtLogin.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(105, 16)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(236, 20)
        Me.txtServidor.TabIndex = 21
        Me.txtServidor.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'fraComandos
        '
        Me.fraComandos.Controls.Add(Me.cmdSair)
        Me.fraComandos.Controls.Add(Me.cmdTestarConexao)
        Me.fraComandos.Controls.Add(Me.cmdOK)
        Me.fraComandos.Location = New System.Drawing.Point(6, 86)
        Me.fraComandos.Name = "fraComandos"
        Me.fraComandos.Size = New System.Drawing.Size(341, 50)
        Me.fraComandos.TabIndex = 20
        Me.fraComandos.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(260, 16)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(75, 27)
        Me.cmdSair.TabIndex = 2
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdTestarConexao
        '
        Me.cmdTestarConexao.Location = New System.Drawing.Point(87, 16)
        Me.cmdTestarConexao.Name = "cmdTestarConexao"
        Me.cmdTestarConexao.Size = New System.Drawing.Size(99, 27)
        Me.cmdTestarConexao.TabIndex = 1
        Me.cmdTestarConexao.Text = "Testar conexão"
        Me.cmdTestarConexao.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(6, 16)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 27)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lblSenha
        '
        Me.lblSenha.AutoSize = True
        Me.lblSenha.Location = New System.Drawing.Point(58, 65)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(41, 13)
        Me.lblSenha.TabIndex = 17
        Me.lblSenha.Text = "Senha:"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(63, 44)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(36, 13)
        Me.lblLogin.TabIndex = 16
        Me.lblLogin.Text = "Login:"
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Location = New System.Drawing.Point(50, 18)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(49, 13)
        Me.lblServidor.TabIndex = 6
        Me.lblServidor.Text = "Servidor:"
        '
        'frmConexaoBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 139)
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConexaoBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SegTrab - Conexão ao Servidor"
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        Me.fraComandos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents txtSenha As DSTextBox.DSTextBox
    Friend WithEvents txtLogin As DSTextBox.DSTextBox
    Friend WithEvents txtServidor As DSTextBox.DSTextBox
    Friend WithEvents fraComandos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdTestarConexao As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblSenha As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblServidor As System.Windows.Forms.Label
End Class
