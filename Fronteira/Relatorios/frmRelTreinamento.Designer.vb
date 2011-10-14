<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelTreinamento
    Inherits DSFronteiraPadrao.frmPadraoRelatorio

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
        Me.components = New System.ComponentModel.Container()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.txtEmpresa = New DSTextBox.DSTextBox()
        Me.cmdEmpresa = New System.Windows.Forms.Button()
        Me.chkTodasEmpresas = New System.Windows.Forms.CheckBox()
        Me.epPadrao = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ttPadrao = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdTipoTreinamento = New System.Windows.Forms.Button()
        Me.cmdTreinamento = New System.Windows.Forms.Button()
        Me.cmdLimparAnaliseCritica = New System.Windows.Forms.Button()
        Me.cmdLimparAprovacao = New System.Windows.Forms.Button()
        Me.chkTodosTiposTreinamentos = New System.Windows.Forms.CheckBox()
        Me.txtTipoTreinamento = New DSTextBox.DSTextBox()
        Me.lblTipoTreinamento = New System.Windows.Forms.Label()
        Me.chkTodosTreinamentos = New System.Windows.Forms.CheckBox()
        Me.txtTreinamento = New DSTextBox.DSTextBox()
        Me.lblTreinamento = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.dtpDataInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.dtpDataFinal = New System.Windows.Forms.DateTimePicker()
        Me.chkTodasDatas = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnaliseCritica = New DSTextBox.DSTextBox()
        Me.txtAprovacao = New DSTextBox.DSTextBox()
        Me.lblAprovacao = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(502, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(76, 160)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(3, 132)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdLimparAprovacao)
        Me.GroupBox2.Controls.Add(Me.txtAprovacao)
        Me.GroupBox2.Controls.Add(Me.lblAprovacao)
        Me.GroupBox2.Controls.Add(Me.cmdLimparAnaliseCritica)
        Me.GroupBox2.Controls.Add(Me.txtAnaliseCritica)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkTodasDatas)
        Me.GroupBox2.Controls.Add(Me.dtpDataFinal)
        Me.GroupBox2.Controls.Add(Me.lblA)
        Me.GroupBox2.Controls.Add(Me.dtpDataInicial)
        Me.GroupBox2.Controls.Add(Me.lblData)
        Me.GroupBox2.Controls.Add(Me.chkTodosTreinamentos)
        Me.GroupBox2.Controls.Add(Me.cmdTreinamento)
        Me.GroupBox2.Controls.Add(Me.txtTreinamento)
        Me.GroupBox2.Controls.Add(Me.lblTreinamento)
        Me.GroupBox2.Controls.Add(Me.chkTodosTiposTreinamentos)
        Me.GroupBox2.Controls.Add(Me.cmdTipoTreinamento)
        Me.GroupBox2.Controls.Add(Me.txtTipoTreinamento)
        Me.GroupBox2.Controls.Add(Me.lblTipoTreinamento)
        Me.GroupBox2.Controls.Add(Me.chkTodasEmpresas)
        Me.GroupBox2.Controls.Add(Me.cmdEmpresa)
        Me.GroupBox2.Controls.Add(Me.txtEmpresa)
        Me.GroupBox2.Controls.Add(Me.lblEmpresa)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Size = New System.Drawing.Size(502, 160)
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(44, 18)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 0
        Me.lblEmpresa.Text = "Empresa:"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Location = New System.Drawing.Point(96, 16)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(203, 20)
        Me.txtEmpresa.TabIndex = 1
        Me.txtEmpresa.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'cmdEmpresa
        '
        Me.cmdEmpresa.Enabled = False
        Me.cmdEmpresa.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdEmpresa.Location = New System.Drawing.Point(301, 14)
        Me.cmdEmpresa.Name = "cmdEmpresa"
        Me.cmdEmpresa.Size = New System.Drawing.Size(22, 23)
        Me.cmdEmpresa.TabIndex = 61
        Me.ttPadrao.SetToolTip(Me.cmdEmpresa, "Selecionar uma empresa")
        Me.cmdEmpresa.UseVisualStyleBackColor = True
        '
        'chkTodasEmpresas
        '
        Me.chkTodasEmpresas.AutoSize = True
        Me.chkTodasEmpresas.Checked = True
        Me.chkTodasEmpresas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasEmpresas.Location = New System.Drawing.Point(329, 16)
        Me.chkTodasEmpresas.Name = "chkTodasEmpresas"
        Me.chkTodasEmpresas.Size = New System.Drawing.Size(118, 17)
        Me.chkTodasEmpresas.TabIndex = 62
        Me.chkTodasEmpresas.Text = "Todas as empresas"
        Me.chkTodasEmpresas.UseVisualStyleBackColor = True
        '
        'epPadrao
        '
        Me.epPadrao.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epPadrao.ContainerControl = Me
        '
        'cmdTipoTreinamento
        '
        Me.cmdTipoTreinamento.Enabled = False
        Me.cmdTipoTreinamento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdTipoTreinamento.Location = New System.Drawing.Point(301, 38)
        Me.cmdTipoTreinamento.Name = "cmdTipoTreinamento"
        Me.cmdTipoTreinamento.Size = New System.Drawing.Size(22, 23)
        Me.cmdTipoTreinamento.TabIndex = 65
        Me.ttPadrao.SetToolTip(Me.cmdTipoTreinamento, "Selecionar uma empresa")
        Me.cmdTipoTreinamento.UseVisualStyleBackColor = True
        '
        'cmdTreinamento
        '
        Me.cmdTreinamento.Enabled = False
        Me.cmdTreinamento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdTreinamento.Location = New System.Drawing.Point(301, 61)
        Me.cmdTreinamento.Name = "cmdTreinamento"
        Me.cmdTreinamento.Size = New System.Drawing.Size(22, 23)
        Me.cmdTreinamento.TabIndex = 69
        Me.ttPadrao.SetToolTip(Me.cmdTreinamento, "Selecionar uma empresa")
        Me.cmdTreinamento.UseVisualStyleBackColor = True
        '
        'cmdLimparAnaliseCritica
        '
        Me.cmdLimparAnaliseCritica.Image = Global.Fronteira.My.Resources.Resources.Limpar
        Me.cmdLimparAnaliseCritica.Location = New System.Drawing.Point(326, 106)
        Me.cmdLimparAnaliseCritica.Name = "cmdLimparAnaliseCritica"
        Me.cmdLimparAnaliseCritica.Size = New System.Drawing.Size(22, 23)
        Me.cmdLimparAnaliseCritica.TabIndex = 78
        Me.cmdLimparAnaliseCritica.Text = "/"
        Me.ttPadrao.SetToolTip(Me.cmdLimparAnaliseCritica, "Limpar campo")
        Me.cmdLimparAnaliseCritica.UseVisualStyleBackColor = True
        '
        'cmdLimparAprovacao
        '
        Me.cmdLimparAprovacao.Image = Global.Fronteira.My.Resources.Resources.Limpar
        Me.cmdLimparAprovacao.Location = New System.Drawing.Point(326, 129)
        Me.cmdLimparAprovacao.Name = "cmdLimparAprovacao"
        Me.cmdLimparAprovacao.Size = New System.Drawing.Size(22, 23)
        Me.cmdLimparAprovacao.TabIndex = 81
        Me.cmdLimparAprovacao.Text = "/"
        Me.ttPadrao.SetToolTip(Me.cmdLimparAprovacao, "Limpar campo")
        Me.cmdLimparAprovacao.UseVisualStyleBackColor = True
        '
        'chkTodosTiposTreinamentos
        '
        Me.chkTodosTiposTreinamentos.AutoSize = True
        Me.chkTodosTiposTreinamentos.Checked = True
        Me.chkTodosTiposTreinamentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosTiposTreinamentos.Location = New System.Drawing.Point(329, 39)
        Me.chkTodosTiposTreinamentos.Name = "chkTodosTiposTreinamentos"
        Me.chkTodosTiposTreinamentos.Size = New System.Drawing.Size(95, 17)
        Me.chkTodosTiposTreinamentos.TabIndex = 66
        Me.chkTodosTiposTreinamentos.Text = "Todos os tipos"
        Me.chkTodosTiposTreinamentos.UseVisualStyleBackColor = True
        '
        'txtTipoTreinamento
        '
        Me.txtTipoTreinamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTipoTreinamento.Enabled = False
        Me.txtTipoTreinamento.Location = New System.Drawing.Point(96, 39)
        Me.txtTipoTreinamento.Name = "txtTipoTreinamento"
        Me.txtTipoTreinamento.ReadOnly = True
        Me.txtTipoTreinamento.Size = New System.Drawing.Size(203, 20)
        Me.txtTipoTreinamento.TabIndex = 64
        Me.txtTipoTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblTipoTreinamento
        '
        Me.lblTipoTreinamento.AutoSize = True
        Me.lblTipoTreinamento.Location = New System.Drawing.Point(6, 41)
        Me.lblTipoTreinamento.Name = "lblTipoTreinamento"
        Me.lblTipoTreinamento.Size = New System.Drawing.Size(89, 13)
        Me.lblTipoTreinamento.TabIndex = 63
        Me.lblTipoTreinamento.Text = "Tipo treinamento:"
        '
        'chkTodosTreinamentos
        '
        Me.chkTodosTreinamentos.AutoSize = True
        Me.chkTodosTreinamentos.Checked = True
        Me.chkTodosTreinamentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosTreinamentos.Location = New System.Drawing.Point(329, 62)
        Me.chkTodosTreinamentos.Name = "chkTodosTreinamentos"
        Me.chkTodosTreinamentos.Size = New System.Drawing.Size(133, 17)
        Me.chkTodosTreinamentos.TabIndex = 70
        Me.chkTodosTreinamentos.Text = "Todos os treinamentos"
        Me.chkTodosTreinamentos.UseVisualStyleBackColor = True
        '
        'txtTreinamento
        '
        Me.txtTreinamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTreinamento.Enabled = False
        Me.txtTreinamento.Location = New System.Drawing.Point(96, 62)
        Me.txtTreinamento.Name = "txtTreinamento"
        Me.txtTreinamento.ReadOnly = True
        Me.txtTreinamento.Size = New System.Drawing.Size(203, 20)
        Me.txtTreinamento.TabIndex = 68
        Me.txtTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblTreinamento
        '
        Me.lblTreinamento.AutoSize = True
        Me.lblTreinamento.Location = New System.Drawing.Point(26, 64)
        Me.lblTreinamento.Name = "lblTreinamento"
        Me.lblTreinamento.Size = New System.Drawing.Size(69, 13)
        Me.lblTreinamento.TabIndex = 67
        Me.lblTreinamento.Text = "Treinamento:"
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(47, 87)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(48, 13)
        Me.lblData.TabIndex = 71
        Me.lblData.Text = "Período:"
        '
        'dtpDataInicial
        '
        Me.dtpDataInicial.Enabled = False
        Me.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataInicial.Location = New System.Drawing.Point(96, 85)
        Me.dtpDataInicial.Name = "dtpDataInicial"
        Me.dtpDataInicial.Size = New System.Drawing.Size(104, 20)
        Me.dtpDataInicial.TabIndex = 72
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(203, 87)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(13, 13)
        Me.lblA.TabIndex = 73
        Me.lblA.Text = "a"
        '
        'dtpDataFinal
        '
        Me.dtpDataFinal.Enabled = False
        Me.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataFinal.Location = New System.Drawing.Point(219, 85)
        Me.dtpDataFinal.Name = "dtpDataFinal"
        Me.dtpDataFinal.Size = New System.Drawing.Size(104, 20)
        Me.dtpDataFinal.TabIndex = 74
        '
        'chkTodasDatas
        '
        Me.chkTodasDatas.AutoSize = True
        Me.chkTodasDatas.Checked = True
        Me.chkTodasDatas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasDatas.Location = New System.Drawing.Point(329, 85)
        Me.chkTodasDatas.Name = "chkTodasDatas"
        Me.chkTodasDatas.Size = New System.Drawing.Size(101, 17)
        Me.chkTodasDatas.TabIndex = 75
        Me.chkTodasDatas.Text = "Todos períodos"
        Me.chkTodasDatas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Análise crítica:"
        '
        'txtAnaliseCritica
        '
        Me.txtAnaliseCritica.Location = New System.Drawing.Point(96, 108)
        Me.txtAnaliseCritica.MaxLength = 50
        Me.txtAnaliseCritica.Name = "txtAnaliseCritica"
        Me.txtAnaliseCritica.Size = New System.Drawing.Size(227, 20)
        Me.txtAnaliseCritica.TabIndex = 77
        Me.txtAnaliseCritica.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtAprovacao
        '
        Me.txtAprovacao.Location = New System.Drawing.Point(96, 131)
        Me.txtAprovacao.MaxLength = 50
        Me.txtAprovacao.Name = "txtAprovacao"
        Me.txtAprovacao.Size = New System.Drawing.Size(227, 20)
        Me.txtAprovacao.TabIndex = 80
        Me.txtAprovacao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblAprovacao
        '
        Me.lblAprovacao.AutoSize = True
        Me.lblAprovacao.Location = New System.Drawing.Point(33, 131)
        Me.lblAprovacao.Name = "lblAprovacao"
        Me.lblAprovacao.Size = New System.Drawing.Size(62, 13)
        Me.lblAprovacao.TabIndex = 79
        Me.lblAprovacao.Text = "Aprovação:"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(490, 151)
        Me.GroupBox3.TabIndex = 84
        Me.GroupBox3.TabStop = False
        '
        'frmRelTreinamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 160)
        Me.Name = "frmRelTreinamento"
        Me.Text = "Relatório de Treinamentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtEmpresa As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents chkTodasEmpresas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEmpresa As System.Windows.Forms.Button
    Friend WithEvents epPadrao As System.Windows.Forms.ErrorProvider
    Friend WithEvents ttPadrao As System.Windows.Forms.ToolTip
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents dtpDataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents chkTodosTreinamentos As System.Windows.Forms.CheckBox
    Friend WithEvents cmdTreinamento As System.Windows.Forms.Button
    Friend WithEvents txtTreinamento As DSTextBox.DSTextBox
    Friend WithEvents lblTreinamento As System.Windows.Forms.Label
    Friend WithEvents chkTodosTiposTreinamentos As System.Windows.Forms.CheckBox
    Friend WithEvents cmdTipoTreinamento As System.Windows.Forms.Button
    Friend WithEvents txtTipoTreinamento As DSTextBox.DSTextBox
    Friend WithEvents lblTipoTreinamento As System.Windows.Forms.Label
    Friend WithEvents chkTodasDatas As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAnaliseCritica As DSTextBox.DSTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdLimparAnaliseCritica As System.Windows.Forms.Button
    Friend WithEvents cmdLimparAprovacao As System.Windows.Forms.Button
    Friend WithEvents txtAprovacao As DSTextBox.DSTextBox
    Friend WithEvents lblAprovacao As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
