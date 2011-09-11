<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCbo
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
        Me.fraPrincipal = New System.Windows.Forms.GroupBox
        Me.txtDescricao = New DSTextBox.DSTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodCBO = New DSTextBox.DSTextBox
        Me.lblFuncao = New System.Windows.Forms.Label
        Me.cmdSelecionarCBO = New System.Windows.Forms.Button
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.cmdSelecionarCBO)
        Me.fraGeral.Controls.Add(Me.fraPrincipal)
        Me.fraGeral.Size = New System.Drawing.Size(362, 173)
        '
        'fraPrincipal
        '
        Me.fraPrincipal.Controls.Add(Me.txtDescricao)
        Me.fraPrincipal.Controls.Add(Me.Label1)
        Me.fraPrincipal.Controls.Add(Me.txtCodCBO)
        Me.fraPrincipal.Controls.Add(Me.lblFuncao)
        Me.fraPrincipal.Location = New System.Drawing.Point(6, 8)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(350, 159)
        Me.fraPrincipal.TabIndex = 0
        Me.fraPrincipal.TabStop = False
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(67, 34)
        Me.txtDescricao.MaxLength = 100
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(277, 20)
        Me.txtDescricao.TabIndex = 4
        Me.txtDescricao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Descrição:"
        '
        'txtCodCBO
        '
        Me.txtCodCBO.Location = New System.Drawing.Point(67, 11)
        Me.txtCodCBO.MaxLength = 7
        Me.txtCodCBO.Name = "txtCodCBO"
        Me.txtCodCBO.Size = New System.Drawing.Size(88, 20)
        Me.txtCodCBO.TabIndex = 1
        Me.txtCodCBO.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblFuncao
        '
        Me.lblFuncao.AutoSize = True
        Me.lblFuncao.Location = New System.Drawing.Point(21, 15)
        Me.lblFuncao.Name = "lblFuncao"
        Me.lblFuncao.Size = New System.Drawing.Size(43, 13)
        Me.lblFuncao.TabIndex = 0
        Me.lblFuncao.Text = "Código:"
        '
        'cmdSelecionarCBO
        '
        Me.cmdSelecionarCBO.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarCBO.Location = New System.Drawing.Point(165, 18)
        Me.cmdSelecionarCBO.Name = "cmdSelecionarCBO"
        Me.cmdSelecionarCBO.Size = New System.Drawing.Size(22, 21)
        Me.cmdSelecionarCBO.TabIndex = 4
        Me.cmdSelecionarCBO.UseVisualStyleBackColor = True
        '
        'frmCbo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 173)
        Me.Name = "frmCbo"
        Me.Text = "Cadastro de CBO"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodCBO As DSTextBox.DSTextBox
    Friend WithEvents lblFuncao As System.Windows.Forms.Label
    Friend WithEvents txtDescricao As DSTextBox.DSTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSelecionarCBO As System.Windows.Forms.Button
End Class
