<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcesso
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcesso))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSenha = New DSTextBox.DSTextBox
        Me.txtLogin = New DSTextBox.DSTextBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblSenha = New System.Windows.Forms.Label
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.epAcesso = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epAcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSenha)
        Me.GroupBox2.Controls.Add(Me.txtLogin)
        Me.GroupBox2.Controls.Add(Me.cmdSair)
        Me.GroupBox2.Controls.Add(Me.cmdOk)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.lblSenha)
        Me.GroupBox2.Controls.Add(Me.lblUsuario)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 117)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(114, 52)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(160, 20)
        Me.txtSenha.TabIndex = 3
        Me.txtSenha.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(114, 25)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(160, 20)
        Me.txtLogin.TabIndex = 0
        Me.txtLogin.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(196, 85)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(78, 25)
        Me.cmdSair.TabIndex = 5
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(114, 85)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 74)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lblSenha
        '
        Me.lblSenha.AutoSize = True
        Me.lblSenha.Location = New System.Drawing.Point(64, 55)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(41, 13)
        Me.lblSenha.TabIndex = 2
        Me.lblSenha.Text = "Senha:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(64, 32)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(46, 13)
        Me.lblUsuario.TabIndex = 1
        Me.lblUsuario.Text = "Usuário:"
        '
        'epAcesso
        '
        Me.epAcesso.ContainerControl = Me
        '
        'frmAcesso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 117)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAcesso"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epAcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSenha As DSTextBox.DSTextBox
    Friend WithEvents txtLogin As DSTextBox.DSTextBox
    Public WithEvents cmdSair As System.Windows.Forms.Button
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lblSenha As System.Windows.Forms.Label
    Public WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents epAcesso As System.Windows.Forms.ErrorProvider
End Class
