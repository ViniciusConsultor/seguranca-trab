<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadNR
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdSelecionarNR = New System.Windows.Forms.Button
        Me.fraPrincipal = New System.Windows.Forms.GroupBox
        Me.fraArtigos = New System.Windows.Forms.GroupBox
        Me.cmdAdicionarArtigo = New System.Windows.Forms.Button
        Me.cmdExcluirArtigo = New System.Windows.Forms.Button
        Me.fraPergunta = New System.Windows.Forms.GroupBox
        Me.cmdAdicionarPergunta = New System.Windows.Forms.Button
        Me.cmdExcluirPergunta = New System.Windows.Forms.Button
        Me.dgvQuestoes = New System.Windows.Forms.DataGridView
        Me.dgvArtigos = New System.Windows.Forms.DataGridView
        Me.txtDescricao = New DSTextBox.DSTextBox
        Me.lblDescricao = New System.Windows.Forms.Label
        Me.txtNR = New DSTextBox.DSTextBox
        Me.lblEmpresa = New System.Windows.Forms.Label
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPrincipal.SuspendLayout()
        Me.fraArtigos.SuspendLayout()
        Me.fraPergunta.SuspendLayout()
        CType(Me.dgvQuestoes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArtigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.cmdSelecionarNR)
        Me.fraGeral.Controls.Add(Me.fraPrincipal)
        Me.fraGeral.Size = New System.Drawing.Size(662, 514)
        '
        'cmdSelecionarNR
        '
        Me.cmdSelecionarNR.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarNR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelecionarNR.Location = New System.Drawing.Point(120, 24)
        Me.cmdSelecionarNR.Name = "cmdSelecionarNR"
        Me.cmdSelecionarNR.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarNR.TabIndex = 71
        Me.ttPadrao.SetToolTip(Me.cmdSelecionarNR, "Selecionar NR")
        Me.cmdSelecionarNR.UseVisualStyleBackColor = True
        '
        'fraPrincipal
        '
        Me.fraPrincipal.Controls.Add(Me.fraArtigos)
        Me.fraPrincipal.Controls.Add(Me.txtDescricao)
        Me.fraPrincipal.Controls.Add(Me.lblDescricao)
        Me.fraPrincipal.Controls.Add(Me.txtNR)
        Me.fraPrincipal.Controls.Add(Me.lblEmpresa)
        Me.fraPrincipal.Location = New System.Drawing.Point(7, 7)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(649, 500)
        Me.fraPrincipal.TabIndex = 70
        Me.fraPrincipal.TabStop = False
        '
        'fraArtigos
        '
        Me.fraArtigos.Controls.Add(Me.cmdAdicionarArtigo)
        Me.fraArtigos.Controls.Add(Me.cmdExcluirArtigo)
        Me.fraArtigos.Controls.Add(Me.fraPergunta)
        Me.fraArtigos.Controls.Add(Me.dgvArtigos)
        Me.fraArtigos.Location = New System.Drawing.Point(10, 105)
        Me.fraArtigos.Name = "fraArtigos"
        Me.fraArtigos.Size = New System.Drawing.Size(627, 385)
        Me.fraArtigos.TabIndex = 67
        Me.fraArtigos.TabStop = False
        Me.fraArtigos.Text = "Artigos"
        '
        'cmdAdicionarArtigo
        '
        Me.cmdAdicionarArtigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarArtigo.BackColor = System.Drawing.Color.Transparent
        Me.cmdAdicionarArtigo.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarArtigo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarArtigo.Location = New System.Drawing.Point(573, 0)
        Me.cmdAdicionarArtigo.Name = "cmdAdicionarArtigo"
        Me.cmdAdicionarArtigo.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarArtigo.TabIndex = 46
        Me.cmdAdicionarArtigo.Tag = ""
        Me.cmdAdicionarArtigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarArtigo.UseVisualStyleBackColor = False
        '
        'cmdExcluirArtigo
        '
        Me.cmdExcluirArtigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirArtigo.BackColor = System.Drawing.Color.Transparent
        Me.cmdExcluirArtigo.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirArtigo.Location = New System.Drawing.Point(594, 0)
        Me.cmdExcluirArtigo.Name = "cmdExcluirArtigo"
        Me.cmdExcluirArtigo.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirArtigo.TabIndex = 47
        Me.cmdExcluirArtigo.Tag = ""
        Me.cmdExcluirArtigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirArtigo.UseVisualStyleBackColor = False
        '
        'fraPergunta
        '
        Me.fraPergunta.Controls.Add(Me.cmdAdicionarPergunta)
        Me.fraPergunta.Controls.Add(Me.cmdExcluirPergunta)
        Me.fraPergunta.Controls.Add(Me.dgvQuestoes)
        Me.fraPergunta.Location = New System.Drawing.Point(6, 282)
        Me.fraPergunta.Name = "fraPergunta"
        Me.fraPergunta.Size = New System.Drawing.Size(614, 97)
        Me.fraPergunta.TabIndex = 1
        Me.fraPergunta.TabStop = False
        Me.fraPergunta.Text = "Questões"
        '
        'cmdAdicionarPergunta
        '
        Me.cmdAdicionarPergunta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarPergunta.BackColor = System.Drawing.Color.Transparent
        Me.cmdAdicionarPergunta.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarPergunta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarPergunta.Location = New System.Drawing.Point(566, -1)
        Me.cmdAdicionarPergunta.Name = "cmdAdicionarPergunta"
        Me.cmdAdicionarPergunta.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarPergunta.TabIndex = 48
        Me.cmdAdicionarPergunta.Tag = ""
        Me.cmdAdicionarPergunta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarPergunta.UseVisualStyleBackColor = False
        '
        'cmdExcluirPergunta
        '
        Me.cmdExcluirPergunta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirPergunta.BackColor = System.Drawing.Color.Transparent
        Me.cmdExcluirPergunta.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirPergunta.Location = New System.Drawing.Point(587, -1)
        Me.cmdExcluirPergunta.Name = "cmdExcluirPergunta"
        Me.cmdExcluirPergunta.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirPergunta.TabIndex = 49
        Me.cmdExcluirPergunta.Tag = ""
        Me.cmdExcluirPergunta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirPergunta.UseVisualStyleBackColor = False
        '
        'dgvQuestoes
        '
        Me.dgvQuestoes.AllowUserToResizeColumns = False
        Me.dgvQuestoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvQuestoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuestoes.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvQuestoes.Location = New System.Drawing.Point(6, 21)
        Me.dgvQuestoes.Name = "dgvQuestoes"
        Me.dgvQuestoes.RowHeadersWidth = 20
        Me.dgvQuestoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuestoes.Size = New System.Drawing.Size(602, 70)
        Me.dgvQuestoes.TabIndex = 2
        '
        'dgvArtigos
        '
        Me.dgvArtigos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArtigos.Location = New System.Drawing.Point(6, 21)
        Me.dgvArtigos.Name = "dgvArtigos"
        Me.dgvArtigos.RowHeadersWidth = 20
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvArtigos.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvArtigos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArtigos.Size = New System.Drawing.Size(614, 255)
        Me.dgvArtigos.TabIndex = 0
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(66, 44)
        Me.txtDescricao.MaxLength = 500
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(571, 57)
        Me.txtDescricao.TabIndex = 65
        Me.txtDescricao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(7, 47)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.lblDescricao.TabIndex = 66
        Me.lblDescricao.Text = "Descrição:"
        '
        'txtNR
        '
        Me.txtNR.Location = New System.Drawing.Point(66, 18)
        Me.txtNR.MaxLength = 30
        Me.txtNR.Name = "txtNR"
        Me.txtNR.Size = New System.Drawing.Size(43, 20)
        Me.txtNR.TabIndex = 63
        Me.txtNR.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(39, 21)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(26, 13)
        Me.lblEmpresa.TabIndex = 64
        Me.lblEmpresa.Text = "NR:"
        '
        'frmCadNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 514)
        Me.Name = "frmCadNR"
        Me.Text = "Cadastro NR"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.fraArtigos.ResumeLayout(False)
        Me.fraPergunta.ResumeLayout(False)
        CType(Me.dgvQuestoes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArtigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSelecionarNR As System.Windows.Forms.Button
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents fraArtigos As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdAdicionarArtigo As System.Windows.Forms.Button
    Protected Friend WithEvents cmdExcluirArtigo As System.Windows.Forms.Button
    Friend WithEvents fraPergunta As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdAdicionarPergunta As System.Windows.Forms.Button
    Protected Friend WithEvents cmdExcluirPergunta As System.Windows.Forms.Button
    Friend WithEvents dgvQuestoes As System.Windows.Forms.DataGridView
    Friend WithEvents dgvArtigos As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescricao As DSTextBox.DSTextBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents txtNR As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
End Class
