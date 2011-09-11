<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFuncao
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpPrincipal = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSelecionarFuncao = New System.Windows.Forms.Button
        Me.fraPrincipal = New System.Windows.Forms.GroupBox
        Me.chkPadrao = New System.Windows.Forms.CheckBox
        Me.txtDescricao = New DSTextBox.DSTextBox
        Me.lblFuncao = New System.Windows.Forms.Label
        Me.tpTreinamento = New System.Windows.Forms.TabPage
        Me.fraTreinamento = New System.Windows.Forms.GroupBox
        Me.cmdExcluirTreinamento = New System.Windows.Forms.Button
        Me.cmdAdicionarTreinamento = New System.Windows.Forms.Button
        Me.dgvTreinamentos = New System.Windows.Forms.DataGridView
        Me.tpEPI = New System.Windows.Forms.TabPage
        Me.fraEPI = New System.Windows.Forms.GroupBox
        Me.cmdExcluirEPI = New System.Windows.Forms.Button
        Me.cmdAdicionarEPI = New System.Windows.Forms.Button
        Me.dgvEPI = New System.Windows.Forms.DataGridView
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpPrincipal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraPrincipal.SuspendLayout()
        Me.tpTreinamento.SuspendLayout()
        Me.fraTreinamento.SuspendLayout()
        CType(Me.dgvTreinamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpEPI.SuspendLayout()
        Me.fraEPI.SuspendLayout()
        CType(Me.dgvEPI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.TabControl1)
        Me.fraGeral.Size = New System.Drawing.Size(362, 173)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpPrincipal)
        Me.TabControl1.Controls.Add(Me.tpTreinamento)
        Me.TabControl1.Controls.Add(Me.tpEPI)
        Me.TabControl1.Location = New System.Drawing.Point(5, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(352, 158)
        Me.TabControl1.TabIndex = 1
        '
        'tpPrincipal
        '
        Me.tpPrincipal.Controls.Add(Me.GroupBox1)
        Me.tpPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tpPrincipal.Name = "tpPrincipal"
        Me.tpPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrincipal.Size = New System.Drawing.Size(344, 132)
        Me.tpPrincipal.TabIndex = 0
        Me.tpPrincipal.Text = "Principal"
        Me.tpPrincipal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSelecionarFuncao)
        Me.GroupBox1.Controls.Add(Me.fraPrincipal)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, -6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 135)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmdSelecionarFuncao
        '
        Me.cmdSelecionarFuncao.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncao.Location = New System.Drawing.Point(287, 15)
        Me.cmdSelecionarFuncao.Name = "cmdSelecionarFuncao"
        Me.cmdSelecionarFuncao.Size = New System.Drawing.Size(22, 22)
        Me.cmdSelecionarFuncao.TabIndex = 8
        Me.cmdSelecionarFuncao.UseVisualStyleBackColor = True
        '
        'fraPrincipal
        '
        Me.fraPrincipal.Controls.Add(Me.chkPadrao)
        Me.fraPrincipal.Controls.Add(Me.txtDescricao)
        Me.fraPrincipal.Controls.Add(Me.lblFuncao)
        Me.fraPrincipal.Location = New System.Drawing.Point(5, 5)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(327, 124)
        Me.fraPrincipal.TabIndex = 1
        Me.fraPrincipal.TabStop = False
        '
        'chkPadrao
        '
        Me.chkPadrao.AutoSize = True
        Me.chkPadrao.Location = New System.Drawing.Point(220, 37)
        Me.chkPadrao.Name = "chkPadrao"
        Me.chkPadrao.Size = New System.Drawing.Size(60, 17)
        Me.chkPadrao.TabIndex = 2
        Me.chkPadrao.Text = "Padrão"
        Me.chkPadrao.UseVisualStyleBackColor = True
        Me.chkPadrao.Visible = False
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(56, 11)
        Me.txtDescricao.MaxLength = 30
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(224, 20)
        Me.txtDescricao.TabIndex = 1
        Me.txtDescricao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblFuncao
        '
        Me.lblFuncao.AutoSize = True
        Me.lblFuncao.Location = New System.Drawing.Point(6, 15)
        Me.lblFuncao.Name = "lblFuncao"
        Me.lblFuncao.Size = New System.Drawing.Size(46, 13)
        Me.lblFuncao.TabIndex = 0
        Me.lblFuncao.Text = "Função:"
        '
        'tpTreinamento
        '
        Me.tpTreinamento.Controls.Add(Me.fraTreinamento)
        Me.tpTreinamento.Location = New System.Drawing.Point(4, 22)
        Me.tpTreinamento.Name = "tpTreinamento"
        Me.tpTreinamento.Size = New System.Drawing.Size(344, 132)
        Me.tpTreinamento.TabIndex = 1
        Me.tpTreinamento.Text = "Treinamentos"
        Me.tpTreinamento.UseVisualStyleBackColor = True
        '
        'fraTreinamento
        '
        Me.fraTreinamento.Controls.Add(Me.cmdExcluirTreinamento)
        Me.fraTreinamento.Controls.Add(Me.cmdAdicionarTreinamento)
        Me.fraTreinamento.Controls.Add(Me.dgvTreinamentos)
        Me.fraTreinamento.Location = New System.Drawing.Point(3, -1)
        Me.fraTreinamento.Name = "fraTreinamento"
        Me.fraTreinamento.Size = New System.Drawing.Size(338, 135)
        Me.fraTreinamento.TabIndex = 5
        Me.fraTreinamento.TabStop = False
        '
        'cmdExcluirTreinamento
        '
        Me.cmdExcluirTreinamento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirTreinamento.BackColor = System.Drawing.Color.Transparent
        Me.cmdExcluirTreinamento.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirTreinamento.Location = New System.Drawing.Point(311, 7)
        Me.cmdExcluirTreinamento.Name = "cmdExcluirTreinamento"
        Me.cmdExcluirTreinamento.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirTreinamento.TabIndex = 43
        Me.cmdExcluirTreinamento.Tag = ""
        Me.cmdExcluirTreinamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirTreinamento.UseVisualStyleBackColor = False
        '
        'cmdAdicionarTreinamento
        '
        Me.cmdAdicionarTreinamento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarTreinamento.BackColor = System.Drawing.Color.Transparent
        Me.cmdAdicionarTreinamento.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarTreinamento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarTreinamento.Location = New System.Drawing.Point(289, 7)
        Me.cmdAdicionarTreinamento.Name = "cmdAdicionarTreinamento"
        Me.cmdAdicionarTreinamento.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarTreinamento.TabIndex = 42
        Me.cmdAdicionarTreinamento.Tag = ""
        Me.cmdAdicionarTreinamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarTreinamento.UseVisualStyleBackColor = False
        '
        'dgvTreinamentos
        '
        Me.dgvTreinamentos.BackgroundColor = System.Drawing.Color.White
        Me.dgvTreinamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTreinamentos.Location = New System.Drawing.Point(6, 26)
        Me.dgvTreinamentos.Name = "dgvTreinamentos"
        Me.dgvTreinamentos.Size = New System.Drawing.Size(326, 101)
        Me.dgvTreinamentos.TabIndex = 1
        '
        'tpEPI
        '
        Me.tpEPI.Controls.Add(Me.fraEPI)
        Me.tpEPI.Location = New System.Drawing.Point(4, 22)
        Me.tpEPI.Name = "tpEPI"
        Me.tpEPI.Size = New System.Drawing.Size(344, 132)
        Me.tpEPI.TabIndex = 2
        Me.tpEPI.Text = "EPI"
        Me.tpEPI.UseVisualStyleBackColor = True
        '
        'fraEPI
        '
        Me.fraEPI.Controls.Add(Me.cmdExcluirEPI)
        Me.fraEPI.Controls.Add(Me.cmdAdicionarEPI)
        Me.fraEPI.Controls.Add(Me.dgvEPI)
        Me.fraEPI.Location = New System.Drawing.Point(3, -1)
        Me.fraEPI.Name = "fraEPI"
        Me.fraEPI.Size = New System.Drawing.Size(338, 135)
        Me.fraEPI.TabIndex = 6
        Me.fraEPI.TabStop = False
        '
        'cmdExcluirEPI
        '
        Me.cmdExcluirEPI.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirEPI.BackColor = System.Drawing.Color.Transparent
        Me.cmdExcluirEPI.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirEPI.Location = New System.Drawing.Point(311, 7)
        Me.cmdExcluirEPI.Name = "cmdExcluirEPI"
        Me.cmdExcluirEPI.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirEPI.TabIndex = 43
        Me.cmdExcluirEPI.Tag = ""
        Me.cmdExcluirEPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirEPI.UseVisualStyleBackColor = False
        '
        'cmdAdicionarEPI
        '
        Me.cmdAdicionarEPI.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarEPI.BackColor = System.Drawing.Color.Transparent
        Me.cmdAdicionarEPI.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarEPI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarEPI.Location = New System.Drawing.Point(289, 7)
        Me.cmdAdicionarEPI.Name = "cmdAdicionarEPI"
        Me.cmdAdicionarEPI.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarEPI.TabIndex = 42
        Me.cmdAdicionarEPI.Tag = ""
        Me.cmdAdicionarEPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarEPI.UseVisualStyleBackColor = False
        '
        'dgvEPI
        '
        Me.dgvEPI.BackgroundColor = System.Drawing.Color.White
        Me.dgvEPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEPI.Location = New System.Drawing.Point(6, 26)
        Me.dgvEPI.Name = "dgvEPI"
        Me.dgvEPI.Size = New System.Drawing.Size(326, 101)
        Me.dgvEPI.TabIndex = 1
        '
        'frmFuncao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 173)
        Me.Name = "frmFuncao"
        Me.Text = "Cadastro de Função"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpPrincipal.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.tpTreinamento.ResumeLayout(False)
        Me.fraTreinamento.ResumeLayout(False)
        CType(Me.dgvTreinamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpEPI.ResumeLayout(False)
        Me.fraEPI.ResumeLayout(False)
        CType(Me.dgvEPI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelecionarFuncao As System.Windows.Forms.Button
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents chkPadrao As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescricao As DSTextBox.DSTextBox
    Friend WithEvents lblFuncao As System.Windows.Forms.Label
    Friend WithEvents tpTreinamento As System.Windows.Forms.TabPage
    Friend WithEvents fraTreinamento As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdExcluirTreinamento As System.Windows.Forms.Button
    Protected Friend WithEvents cmdAdicionarTreinamento As System.Windows.Forms.Button
    Friend WithEvents dgvTreinamentos As System.Windows.Forms.DataGridView
    Friend WithEvents tpEPI As System.Windows.Forms.TabPage
    Friend WithEvents fraEPI As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdExcluirEPI As System.Windows.Forms.Button
    Protected Friend WithEvents cmdAdicionarEPI As System.Windows.Forms.Button
    Friend WithEvents dgvEPI As System.Windows.Forms.DataGridView
End Class
