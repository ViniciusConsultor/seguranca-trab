<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportacaoFunc
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
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.lblInvalidos = New System.Windows.Forms.Label
        Me.lblDescInvalidos = New System.Windows.Forms.Label
        Me.lblValidos = New System.Windows.Forms.Label
        Me.lblDescValidos = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblRegProcessados = New System.Windows.Forms.Label
        Me.dgvImportacao = New System.Windows.Forms.DataGridView
        Me.fraOpcoes = New System.Windows.Forms.GroupBox
        Me.cmdAplicar = New System.Windows.Forms.Button
        Me.txtDataAdmissao = New System.Windows.Forms.DateTimePicker
        Me.chkDataAdmissao = New System.Windows.Forms.CheckBox
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.chkEstado = New System.Windows.Forms.CheckBox
        Me.txtCidade = New System.Windows.Forms.TextBox
        Me.chkCidade = New System.Windows.Forms.CheckBox
        Me.cmdSelecionarFuncao = New System.Windows.Forms.Button
        Me.lblFuncao = New System.Windows.Forms.Label
        Me.chkFuncao = New System.Windows.Forms.CheckBox
        Me.fraCabecalho = New System.Windows.Forms.GroupBox
        Me.cmdArquivo = New System.Windows.Forms.Button
        Me.lblDescArquivo = New System.Windows.Forms.Label
        Me.lblArquivo = New System.Windows.Forms.Label
        Me.lblDescricaoEmpresa = New System.Windows.Forms.Label
        Me.lblEmpresa = New System.Windows.Forms.Label
        Me.fraCmd = New System.Windows.Forms.GroupBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdProcessar = New System.Windows.Forms.Button
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdImportar = New System.Windows.Forms.Button
        Me.ttImportacao = New System.Windows.Forms.ToolTip(Me.components)
        Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.fraGeral.SuspendLayout()
        CType(Me.dgvImportacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraOpcoes.SuspendLayout()
        Me.fraCabecalho.SuspendLayout()
        Me.fraCmd.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.lblInvalidos)
        Me.fraGeral.Controls.Add(Me.lblDescInvalidos)
        Me.fraGeral.Controls.Add(Me.lblValidos)
        Me.fraGeral.Controls.Add(Me.lblDescValidos)
        Me.fraGeral.Controls.Add(Me.lblTotal)
        Me.fraGeral.Controls.Add(Me.lblRegProcessados)
        Me.fraGeral.Controls.Add(Me.dgvImportacao)
        Me.fraGeral.Controls.Add(Me.fraOpcoes)
        Me.fraGeral.Controls.Add(Me.fraCabecalho)
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(936, 507)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'lblInvalidos
        '
        Me.lblInvalidos.BackColor = System.Drawing.Color.White
        Me.lblInvalidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvalidos.ForeColor = System.Drawing.Color.Maroon
        Me.lblInvalidos.Location = New System.Drawing.Point(801, 424)
        Me.lblInvalidos.Name = "lblInvalidos"
        Me.lblInvalidos.Size = New System.Drawing.Size(37, 16)
        Me.lblInvalidos.TabIndex = 8
        Me.lblInvalidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescInvalidos
        '
        Me.lblDescInvalidos.AutoSize = True
        Me.lblDescInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescInvalidos.ForeColor = System.Drawing.Color.Maroon
        Me.lblDescInvalidos.Location = New System.Drawing.Point(733, 426)
        Me.lblDescInvalidos.Name = "lblDescInvalidos"
        Me.lblDescInvalidos.Size = New System.Drawing.Size(62, 13)
        Me.lblDescInvalidos.TabIndex = 7
        Me.lblDescInvalidos.Text = "Inválidos:"
        '
        'lblValidos
        '
        Me.lblValidos.BackColor = System.Drawing.Color.White
        Me.lblValidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblValidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidos.ForeColor = System.Drawing.Color.Navy
        Me.lblValidos.Location = New System.Drawing.Point(631, 424)
        Me.lblValidos.Name = "lblValidos"
        Me.lblValidos.Size = New System.Drawing.Size(37, 16)
        Me.lblValidos.TabIndex = 6
        Me.lblValidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescValidos
        '
        Me.lblDescValidos.AutoSize = True
        Me.lblDescValidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescValidos.ForeColor = System.Drawing.Color.Navy
        Me.lblDescValidos.Location = New System.Drawing.Point(575, 426)
        Me.lblDescValidos.Name = "lblDescValidos"
        Me.lblDescValidos.Size = New System.Drawing.Size(52, 13)
        Me.lblDescValidos.TabIndex = 5
        Me.lblDescValidos.Text = "Válidos:"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(460, 424)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 16)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRegProcessados
        '
        Me.lblRegProcessados.AutoSize = True
        Me.lblRegProcessados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegProcessados.Location = New System.Drawing.Point(320, 426)
        Me.lblRegProcessados.Name = "lblRegProcessados"
        Me.lblRegProcessados.Size = New System.Drawing.Size(139, 13)
        Me.lblRegProcessados.TabIndex = 3
        Me.lblRegProcessados.Text = "Registros processados:"
        '
        'dgvImportacao
        '
        Me.dgvImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportacao.Location = New System.Drawing.Point(6, 51)
        Me.dgvImportacao.Name = "dgvImportacao"
        Me.dgvImportacao.Size = New System.Drawing.Size(832, 370)
        Me.dgvImportacao.TabIndex = 2
        '
        'fraOpcoes
        '
        Me.fraOpcoes.Controls.Add(Me.cmdAplicar)
        Me.fraOpcoes.Controls.Add(Me.txtDataAdmissao)
        Me.fraOpcoes.Controls.Add(Me.chkDataAdmissao)
        Me.fraOpcoes.Controls.Add(Me.cboEstado)
        Me.fraOpcoes.Controls.Add(Me.chkEstado)
        Me.fraOpcoes.Controls.Add(Me.txtCidade)
        Me.fraOpcoes.Controls.Add(Me.chkCidade)
        Me.fraOpcoes.Controls.Add(Me.cmdSelecionarFuncao)
        Me.fraOpcoes.Controls.Add(Me.lblFuncao)
        Me.fraOpcoes.Controls.Add(Me.chkFuncao)
        Me.fraOpcoes.Location = New System.Drawing.Point(6, 438)
        Me.fraOpcoes.Name = "fraOpcoes"
        Me.fraOpcoes.Size = New System.Drawing.Size(832, 63)
        Me.fraOpcoes.TabIndex = 1
        Me.fraOpcoes.TabStop = False
        '
        'cmdAplicar
        '
        Me.cmdAplicar.Location = New System.Drawing.Point(724, 30)
        Me.cmdAplicar.Name = "cmdAplicar"
        Me.cmdAplicar.Size = New System.Drawing.Size(101, 25)
        Me.cmdAplicar.TabIndex = 20
        Me.cmdAplicar.Text = "Aplicar a Todos"
        Me.cmdAplicar.UseVisualStyleBackColor = True
        '
        'txtDataAdmissao
        '
        Me.txtDataAdmissao.Enabled = False
        Me.txtDataAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataAdmissao.Location = New System.Drawing.Point(86, 38)
        Me.txtDataAdmissao.Name = "txtDataAdmissao"
        Me.txtDataAdmissao.Size = New System.Drawing.Size(88, 20)
        Me.txtDataAdmissao.TabIndex = 19
        '
        'chkDataAdmissao
        '
        Me.chkDataAdmissao.AutoSize = True
        Me.chkDataAdmissao.Location = New System.Drawing.Point(9, 38)
        Me.chkDataAdmissao.Name = "chkDataAdmissao"
        Me.chkDataAdmissao.Size = New System.Drawing.Size(74, 17)
        Me.chkDataAdmissao.TabIndex = 18
        Me.chkDataAdmissao.Text = "Admissão:"
        Me.chkDataAdmissao.UseVisualStyleBackColor = True
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(414, 37)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(84, 21)
        Me.cboEstado.TabIndex = 17
        '
        'chkEstado
        '
        Me.chkEstado.AutoSize = True
        Me.chkEstado.Location = New System.Drawing.Point(343, 39)
        Me.chkEstado.Name = "chkEstado"
        Me.chkEstado.Size = New System.Drawing.Size(62, 17)
        Me.chkEstado.TabIndex = 15
        Me.chkEstado.Text = "Estado:"
        Me.chkEstado.UseVisualStyleBackColor = True
        '
        'txtCidade
        '
        Me.txtCidade.Enabled = False
        Me.txtCidade.Location = New System.Drawing.Point(414, 12)
        Me.txtCidade.MaxLength = 30
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(205, 20)
        Me.txtCidade.TabIndex = 14
        '
        'chkCidade
        '
        Me.chkCidade.AutoSize = True
        Me.chkCidade.Location = New System.Drawing.Point(343, 13)
        Me.chkCidade.Name = "chkCidade"
        Me.chkCidade.Size = New System.Drawing.Size(62, 17)
        Me.chkCidade.TabIndex = 13
        Me.chkCidade.Text = "Cidade:"
        Me.chkCidade.UseVisualStyleBackColor = True
        '
        'cmdSelecionarFuncao
        '
        Me.cmdSelecionarFuncao.Enabled = False
        Me.cmdSelecionarFuncao.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncao.Location = New System.Drawing.Point(297, 12)
        Me.cmdSelecionarFuncao.Name = "cmdSelecionarFuncao"
        Me.cmdSelecionarFuncao.Size = New System.Drawing.Size(22, 22)
        Me.cmdSelecionarFuncao.TabIndex = 12
        Me.cmdSelecionarFuncao.UseVisualStyleBackColor = True
        '
        'lblFuncao
        '
        Me.lblFuncao.BackColor = System.Drawing.Color.White
        Me.lblFuncao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFuncao.Location = New System.Drawing.Point(86, 13)
        Me.lblFuncao.Name = "lblFuncao"
        Me.lblFuncao.Size = New System.Drawing.Size(205, 20)
        Me.lblFuncao.TabIndex = 11
        Me.lblFuncao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkFuncao
        '
        Me.chkFuncao.AutoSize = True
        Me.chkFuncao.Location = New System.Drawing.Point(9, 15)
        Me.chkFuncao.Name = "chkFuncao"
        Me.chkFuncao.Size = New System.Drawing.Size(65, 17)
        Me.chkFuncao.TabIndex = 10
        Me.chkFuncao.Text = "Função:"
        Me.chkFuncao.UseVisualStyleBackColor = True
        '
        'fraCabecalho
        '
        Me.fraCabecalho.Controls.Add(Me.cmdArquivo)
        Me.fraCabecalho.Controls.Add(Me.lblDescArquivo)
        Me.fraCabecalho.Controls.Add(Me.lblArquivo)
        Me.fraCabecalho.Controls.Add(Me.lblDescricaoEmpresa)
        Me.fraCabecalho.Controls.Add(Me.lblEmpresa)
        Me.fraCabecalho.Location = New System.Drawing.Point(6, 9)
        Me.fraCabecalho.Name = "fraCabecalho"
        Me.fraCabecalho.Size = New System.Drawing.Size(832, 38)
        Me.fraCabecalho.TabIndex = 0
        Me.fraCabecalho.TabStop = False
        '
        'cmdArquivo
        '
        Me.cmdArquivo.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdArquivo.Location = New System.Drawing.Point(803, 12)
        Me.cmdArquivo.Name = "cmdArquivo"
        Me.cmdArquivo.Size = New System.Drawing.Size(22, 22)
        Me.cmdArquivo.TabIndex = 12
        Me.cmdArquivo.UseVisualStyleBackColor = True
        '
        'lblDescArquivo
        '
        Me.lblDescArquivo.BackColor = System.Drawing.Color.White
        Me.lblDescArquivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescArquivo.Location = New System.Drawing.Point(366, 12)
        Me.lblDescArquivo.Name = "lblDescArquivo"
        Me.lblDescArquivo.Size = New System.Drawing.Size(432, 20)
        Me.lblDescArquivo.TabIndex = 11
        Me.lblDescArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArquivo
        '
        Me.lblArquivo.AutoSize = True
        Me.lblArquivo.Location = New System.Drawing.Point(314, 16)
        Me.lblArquivo.Name = "lblArquivo"
        Me.lblArquivo.Size = New System.Drawing.Size(46, 13)
        Me.lblArquivo.TabIndex = 10
        Me.lblArquivo.Text = "Arquivo:"
        '
        'lblDescricaoEmpresa
        '
        Me.lblDescricaoEmpresa.BackColor = System.Drawing.Color.White
        Me.lblDescricaoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescricaoEmpresa.Location = New System.Drawing.Point(58, 12)
        Me.lblDescricaoEmpresa.Name = "lblDescricaoEmpresa"
        Me.lblDescricaoEmpresa.Size = New System.Drawing.Size(250, 20)
        Me.lblDescricaoEmpresa.TabIndex = 1
        Me.lblDescricaoEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(6, 16)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 0
        Me.lblEmpresa.Text = "Empresa:"
        '
        'fraCmd
        '
        Me.fraCmd.Controls.Add(Me.cmdCancelar)
        Me.fraCmd.Controls.Add(Me.cmdProcessar)
        Me.fraCmd.Controls.Add(Me.cmdSair)
        Me.fraCmd.Controls.Add(Me.cmdImportar)
        Me.fraCmd.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraCmd.Location = New System.Drawing.Point(844, 0)
        Me.fraCmd.Name = "fraCmd"
        Me.fraCmd.Size = New System.Drawing.Size(92, 507)
        Me.fraCmd.TabIndex = 1
        Me.fraCmd.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(6, 75)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdProcessar
        '
        Me.cmdProcessar.Location = New System.Drawing.Point(6, 13)
        Me.cmdProcessar.Name = "cmdProcessar"
        Me.cmdProcessar.Size = New System.Drawing.Size(80, 25)
        Me.cmdProcessar.TabIndex = 14
        Me.cmdProcessar.Text = "Processar"
        Me.cmdProcessar.UseVisualStyleBackColor = True
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(6, 475)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(80, 25)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdImportar
        '
        Me.cmdImportar.Location = New System.Drawing.Point(6, 44)
        Me.cmdImportar.Name = "cmdImportar"
        Me.cmdImportar.Size = New System.Drawing.Size(80, 25)
        Me.cmdImportar.TabIndex = 0
        Me.cmdImportar.Text = "Importar"
        Me.cmdImportar.UseVisualStyleBackColor = True
        '
        'imgLst
        '
        Me.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLst.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmImportacaoFunc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 507)
        Me.Controls.Add(Me.fraCmd)
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportacaoFunc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importacao de Funcionários"
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        CType(Me.dgvImportacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraOpcoes.ResumeLayout(False)
        Me.fraOpcoes.PerformLayout()
        Me.fraCabecalho.ResumeLayout(False)
        Me.fraCabecalho.PerformLayout()
        Me.fraCmd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents fraCmd As System.Windows.Forms.GroupBox
    Friend WithEvents fraCabecalho As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescricaoEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdImportar As System.Windows.Forms.Button
    Friend WithEvents cmdArquivo As System.Windows.Forms.Button
    Friend WithEvents lblDescArquivo As System.Windows.Forms.Label
    Friend WithEvents lblArquivo As System.Windows.Forms.Label
    Friend WithEvents fraOpcoes As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelecionarFuncao As System.Windows.Forms.Button
    Friend WithEvents lblFuncao As System.Windows.Forms.Label
    Friend WithEvents chkFuncao As System.Windows.Forms.CheckBox
    Friend WithEvents dgvImportacao As System.Windows.Forms.DataGridView
    Friend WithEvents cmdProcessar As System.Windows.Forms.Button
    Friend WithEvents txtDataAdmissao As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDataAdmissao As System.Windows.Forms.CheckBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents chkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents txtCidade As System.Windows.Forms.TextBox
    Friend WithEvents chkCidade As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAplicar As System.Windows.Forms.Button
    Friend WithEvents ttImportacao As System.Windows.Forms.ToolTip
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblInvalidos As System.Windows.Forms.Label
    Friend WithEvents lblDescInvalidos As System.Windows.Forms.Label
    Friend WithEvents lblValidos As System.Windows.Forms.Label
    Friend WithEvents lblDescValidos As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblRegProcessados As System.Windows.Forms.Label
    Friend WithEvents imgLst As System.Windows.Forms.ImageList
End Class
