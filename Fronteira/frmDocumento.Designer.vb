<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumento
    Inherits Windows.Forms.Form

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
        Me.fraComandos = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.cmdSelecionarDocumento = New System.Windows.Forms.Button
        Me.txtDescricao = New DSTextBox.DSTextBox
        Me.txtNome = New DSTextBox.DSTextBox
        Me.lblDescricao = New System.Windows.Forms.Label
        Me.lblNome = New System.Windows.Forms.Label
        Me.ofdDocumento = New System.Windows.Forms.OpenFileDialog
        Me.epPadrao = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ttPadrao = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraComandos.SuspendLayout()
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraComandos
        '
        Me.fraComandos.Controls.Add(Me.cmdSair)
        Me.fraComandos.Controls.Add(Me.cmdGravar)
        Me.fraComandos.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComandos.Location = New System.Drawing.Point(374, 0)
        Me.fraComandos.Name = "fraComandos"
        Me.fraComandos.Size = New System.Drawing.Size(98, 91)
        Me.fraComandos.TabIndex = 5
        Me.fraComandos.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 61)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(92, 27)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdGravar
        '
        Me.cmdGravar.Location = New System.Drawing.Point(3, 13)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(92, 27)
        Me.cmdGravar.TabIndex = 0
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = True
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.cmdSelecionarDocumento)
        Me.fraGeral.Controls.Add(Me.txtDescricao)
        Me.fraGeral.Controls.Add(Me.txtNome)
        Me.fraGeral.Controls.Add(Me.lblDescricao)
        Me.fraGeral.Controls.Add(Me.lblNome)
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(472, 91)
        Me.fraGeral.TabIndex = 4
        Me.fraGeral.TabStop = False
        '
        'cmdSelecionarDocumento
        '
        Me.cmdSelecionarDocumento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarDocumento.Location = New System.Drawing.Point(323, 14)
        Me.cmdSelecionarDocumento.Name = "cmdSelecionarDocumento"
        Me.cmdSelecionarDocumento.Size = New System.Drawing.Size(22, 22)
        Me.cmdSelecionarDocumento.TabIndex = 4
        Me.cmdSelecionarDocumento.UseVisualStyleBackColor = True
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(72, 39)
        Me.txtDescricao.MaxLength = 50
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(247, 20)
        Me.txtDescricao.TabIndex = 2
        Me.txtDescricao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(72, 16)
        Me.txtNome.MaxLength = 30
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(247, 20)
        Me.txtNome.TabIndex = 1
        Me.txtNome.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(12, 41)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.lblDescricao.TabIndex = 2
        Me.lblDescricao.Text = "Descrição:"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.Location = New System.Drawing.Point(5, 18)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(65, 13)
        Me.lblNome.TabIndex = 0
        Me.lblNome.Text = "Documento:"
        '
        'ofdDocumento
        '
        Me.ofdDocumento.FileName = "OpenFileDialog1"
        '
        'epPadrao
        '
        Me.epPadrao.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epPadrao.ContainerControl = Me
        '
        'ttPadrao
        '
        Me.ttPadrao.ToolTipTitle = "Selecionar um documento"
        '
        'frmDocumento
        '
        Me.AcceptButton = Me.cmdGravar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 91)
        Me.Controls.Add(Me.fraComandos)
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDocumento"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documento"
        Me.fraComandos.ResumeLayout(False)
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraComandos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents ofdDocumento As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtNome As DSTextBox.DSTextBox
    Friend WithEvents txtDescricao As DSTextBox.DSTextBox
    Friend WithEvents epPadrao As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdSelecionarDocumento As System.Windows.Forms.Button
    Friend WithEvents ttPadrao As System.Windows.Forms.ToolTip
End Class
