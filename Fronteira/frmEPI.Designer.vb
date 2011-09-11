<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEPI
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
        Me.txtFornecedor = New DSTextBox.DSTextBox
        Me.lblFornecedor = New System.Windows.Forms.Label
        Me.chkDevolucaoObrigatoria = New System.Windows.Forms.CheckBox
        Me.txtValidade = New DSTextBox.DSTextBox
        Me.lblMeses = New System.Windows.Forms.Label
        Me.lblValidade = New System.Windows.Forms.Label
        Me.txtCA = New DSTextBox.DSTextBox
        Me.lblCA = New System.Windows.Forms.Label
        Me.txtEPI = New DSTextBox.DSTextBox
        Me.lblDescricao = New System.Windows.Forms.Label
        Me.cmdSelecionarEPI = New System.Windows.Forms.Button
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.fraPrincipal)
        Me.fraGeral.Size = New System.Drawing.Size(362, 172)
        '
        'fraPrincipal
        '
        Me.fraPrincipal.Controls.Add(Me.txtFornecedor)
        Me.fraPrincipal.Controls.Add(Me.lblFornecedor)
        Me.fraPrincipal.Controls.Add(Me.chkDevolucaoObrigatoria)
        Me.fraPrincipal.Controls.Add(Me.txtValidade)
        Me.fraPrincipal.Controls.Add(Me.lblMeses)
        Me.fraPrincipal.Controls.Add(Me.lblValidade)
        Me.fraPrincipal.Controls.Add(Me.txtCA)
        Me.fraPrincipal.Controls.Add(Me.lblCA)
        Me.fraPrincipal.Controls.Add(Me.txtEPI)
        Me.fraPrincipal.Controls.Add(Me.lblDescricao)
        Me.fraPrincipal.Location = New System.Drawing.Point(8, 8)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(348, 157)
        Me.fraPrincipal.TabIndex = 0
        Me.fraPrincipal.TabStop = False
        '
        'txtFornecedor
        '
        Me.txtFornecedor.Location = New System.Drawing.Point(69, 38)
        Me.txtFornecedor.MaxLength = 30
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(229, 20)
        Me.txtFornecedor.TabIndex = 3
        Me.txtFornecedor.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblFornecedor
        '
        Me.lblFornecedor.AutoSize = True
        Me.lblFornecedor.Location = New System.Drawing.Point(5, 42)
        Me.lblFornecedor.Name = "lblFornecedor"
        Me.lblFornecedor.Size = New System.Drawing.Size(64, 13)
        Me.lblFornecedor.TabIndex = 2
        Me.lblFornecedor.Text = "Fornecedor:"
        '
        'chkDevolucaoObrigatoria
        '
        Me.chkDevolucaoObrigatoria.AutoSize = True
        Me.chkDevolucaoObrigatoria.Location = New System.Drawing.Point(69, 112)
        Me.chkDevolucaoObrigatoria.Name = "chkDevolucaoObrigatoria"
        Me.chkDevolucaoObrigatoria.Size = New System.Drawing.Size(130, 17)
        Me.chkDevolucaoObrigatoria.TabIndex = 9
        Me.chkDevolucaoObrigatoria.Text = "Devolução obrigatória"
        Me.chkDevolucaoObrigatoria.UseVisualStyleBackColor = True
        Me.chkDevolucaoObrigatoria.Visible = False
        '
        'txtValidade
        '
        Me.txtValidade.Location = New System.Drawing.Point(69, 86)
        Me.txtValidade.MaxLength = 3
        Me.txtValidade.Name = "txtValidade"
        Me.txtValidade.Size = New System.Drawing.Size(100, 20)
        Me.txtValidade.TabIndex = 7
        Me.txtValidade.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblMeses
        '
        Me.lblMeses.AutoSize = True
        Me.lblMeses.Location = New System.Drawing.Point(175, 89)
        Me.lblMeses.Name = "lblMeses"
        Me.lblMeses.Size = New System.Drawing.Size(37, 13)
        Me.lblMeses.TabIndex = 8
        Me.lblMeses.Text = "meses"
        '
        'lblValidade
        '
        Me.lblValidade.AutoSize = True
        Me.lblValidade.Location = New System.Drawing.Point(18, 89)
        Me.lblValidade.Name = "lblValidade"
        Me.lblValidade.Size = New System.Drawing.Size(51, 13)
        Me.lblValidade.TabIndex = 6
        Me.lblValidade.Text = "Validade:"
        '
        'txtCA
        '
        Me.txtCA.Location = New System.Drawing.Point(69, 62)
        Me.txtCA.MaxLength = 6
        Me.txtCA.Name = "txtCA"
        Me.txtCA.Size = New System.Drawing.Size(100, 20)
        Me.txtCA.TabIndex = 5
        Me.txtCA.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblCA
        '
        Me.lblCA.AutoSize = True
        Me.lblCA.Location = New System.Drawing.Point(45, 66)
        Me.lblCA.Name = "lblCA"
        Me.lblCA.Size = New System.Drawing.Size(24, 13)
        Me.lblCA.TabIndex = 4
        Me.lblCA.Text = "CA:"
        '
        'txtEPI
        '
        Me.txtEPI.Location = New System.Drawing.Point(69, 13)
        Me.txtEPI.MaxLength = 50
        Me.txtEPI.Name = "txtEPI"
        Me.txtEPI.Size = New System.Drawing.Size(229, 20)
        Me.txtEPI.TabIndex = 1
        Me.txtEPI.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(42, 17)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(27, 13)
        Me.lblDescricao.TabIndex = 0
        Me.lblDescricao.Text = "EPI:"
        '
        'cmdSelecionarEPI
        '
        Me.cmdSelecionarEPI.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarEPI.Location = New System.Drawing.Point(309, 20)
        Me.cmdSelecionarEPI.Name = "cmdSelecionarEPI"
        Me.cmdSelecionarEPI.Size = New System.Drawing.Size(23, 23)
        Me.cmdSelecionarEPI.TabIndex = 0
        Me.ttPadrao.SetToolTip(Me.cmdSelecionarEPI, "Seleciona EPI")
        Me.cmdSelecionarEPI.UseVisualStyleBackColor = True
        '
        'frmEPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 172)
        Me.Controls.Add(Me.cmdSelecionarEPI)
        Me.Name = "frmEPI"
        Me.Text = "Cadastro de EPI"
        Me.Controls.SetChildIndex(Me.fraGeral, 0)
        Me.Controls.SetChildIndex(Me.cmdSelecionarEPI, 0)
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents txtEPI As DSTextBox.DSTextBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents txtCA As DSTextBox.DSTextBox
    Friend WithEvents lblCA As System.Windows.Forms.Label
    Friend WithEvents txtValidade As DSTextBox.DSTextBox
    Friend WithEvents lblMeses As System.Windows.Forms.Label
    Friend WithEvents lblValidade As System.Windows.Forms.Label
    Friend WithEvents chkDevolucaoObrigatoria As System.Windows.Forms.CheckBox
    Friend WithEvents txtFornecedor As DSTextBox.DSTextBox
    Friend WithEvents lblFornecedor As System.Windows.Forms.Label
    Friend WithEvents cmdSelecionarEPI As System.Windows.Forms.Button
End Class
