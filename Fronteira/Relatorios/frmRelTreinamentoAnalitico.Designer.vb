<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelTreinamentoAnalitico
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
        Me.epRelatorio = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkTodasDatas = New System.Windows.Forms.CheckBox()
        Me.dtpDataFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.dtpDataInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblData = New System.Windows.Forms.Label()
        Me.chkTodosTreinamentos = New System.Windows.Forms.CheckBox()
        Me.cmdTreinamento = New System.Windows.Forms.Button()
        Me.txtTreinamento = New DSTextBox.DSTextBox()
        Me.lblTreinamento = New System.Windows.Forms.Label()
        Me.chkTodosTiposTreinamentos = New System.Windows.Forms.CheckBox()
        Me.cmdTipoTreinamento = New System.Windows.Forms.Button()
        Me.txtTipoTreinamento = New DSTextBox.DSTextBox()
        Me.lblTipoTreinamento = New System.Windows.Forms.Label()
        Me.chkTodasEmpresas = New System.Windows.Forms.CheckBox()
        Me.cmdEmpresa = New System.Windows.Forms.Button()
        Me.txtEmpresa = New DSTextBox.DSTextBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.chkMostrarFuncionarios = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.epRelatorio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(495, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(76, 149)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(3, 121)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Size = New System.Drawing.Size(495, 149)
        '
        'epRelatorio
        '
        Me.epRelatorio.ContainerControl = Me
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.chkMostrarFuncionarios)
        Me.GroupBox3.Controls.Add(Me.chkTodasDatas)
        Me.GroupBox3.Controls.Add(Me.dtpDataFinal)
        Me.GroupBox3.Controls.Add(Me.lblA)
        Me.GroupBox3.Controls.Add(Me.dtpDataInicial)
        Me.GroupBox3.Controls.Add(Me.lblData)
        Me.GroupBox3.Controls.Add(Me.chkTodosTreinamentos)
        Me.GroupBox3.Controls.Add(Me.cmdTreinamento)
        Me.GroupBox3.Controls.Add(Me.txtTreinamento)
        Me.GroupBox3.Controls.Add(Me.lblTreinamento)
        Me.GroupBox3.Controls.Add(Me.chkTodosTiposTreinamentos)
        Me.GroupBox3.Controls.Add(Me.cmdTipoTreinamento)
        Me.GroupBox3.Controls.Add(Me.txtTipoTreinamento)
        Me.GroupBox3.Controls.Add(Me.lblTipoTreinamento)
        Me.GroupBox3.Controls.Add(Me.chkTodasEmpresas)
        Me.GroupBox3.Controls.Add(Me.cmdEmpresa)
        Me.GroupBox3.Controls.Add(Me.txtEmpresa)
        Me.GroupBox3.Controls.Add(Me.lblEmpresa)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(490, 135)
        Me.GroupBox3.TabIndex = 86
        Me.GroupBox3.TabStop = False
        '
        'chkTodasDatas
        '
        Me.chkTodasDatas.AutoSize = True
        Me.chkTodasDatas.Checked = True
        Me.chkTodasDatas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasDatas.Location = New System.Drawing.Point(332, 85)
        Me.chkTodasDatas.Name = "chkTodasDatas"
        Me.chkTodasDatas.Size = New System.Drawing.Size(101, 17)
        Me.chkTodasDatas.TabIndex = 87
        Me.chkTodasDatas.Text = "Todos períodos"
        Me.chkTodasDatas.UseVisualStyleBackColor = True
        '
        'dtpDataFinal
        '
        Me.dtpDataFinal.Enabled = False
        Me.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataFinal.Location = New System.Drawing.Point(222, 85)
        Me.dtpDataFinal.Name = "dtpDataFinal"
        Me.dtpDataFinal.Size = New System.Drawing.Size(104, 20)
        Me.dtpDataFinal.TabIndex = 86
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(206, 87)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(13, 13)
        Me.lblA.TabIndex = 85
        Me.lblA.Text = "a"
        '
        'dtpDataInicial
        '
        Me.dtpDataInicial.Enabled = False
        Me.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataInicial.Location = New System.Drawing.Point(99, 85)
        Me.dtpDataInicial.Name = "dtpDataInicial"
        Me.dtpDataInicial.Size = New System.Drawing.Size(104, 20)
        Me.dtpDataInicial.TabIndex = 84
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(50, 87)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(48, 13)
        Me.lblData.TabIndex = 83
        Me.lblData.Text = "Período:"
        '
        'chkTodosTreinamentos
        '
        Me.chkTodosTreinamentos.AutoSize = True
        Me.chkTodosTreinamentos.Checked = True
        Me.chkTodosTreinamentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosTreinamentos.Location = New System.Drawing.Point(332, 61)
        Me.chkTodosTreinamentos.Name = "chkTodosTreinamentos"
        Me.chkTodosTreinamentos.Size = New System.Drawing.Size(133, 17)
        Me.chkTodosTreinamentos.TabIndex = 82
        Me.chkTodosTreinamentos.Text = "Todos os treinamentos"
        Me.chkTodosTreinamentos.UseVisualStyleBackColor = True
        '
        'cmdTreinamento
        '
        Me.cmdTreinamento.Enabled = False
        Me.cmdTreinamento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdTreinamento.Location = New System.Drawing.Point(304, 60)
        Me.cmdTreinamento.Name = "cmdTreinamento"
        Me.cmdTreinamento.Size = New System.Drawing.Size(22, 23)
        Me.cmdTreinamento.TabIndex = 81
        Me.cmdTreinamento.UseVisualStyleBackColor = True
        '
        'txtTreinamento
        '
        Me.txtTreinamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTreinamento.Enabled = False
        Me.txtTreinamento.Location = New System.Drawing.Point(99, 61)
        Me.txtTreinamento.Name = "txtTreinamento"
        Me.txtTreinamento.ReadOnly = True
        Me.txtTreinamento.Size = New System.Drawing.Size(203, 20)
        Me.txtTreinamento.TabIndex = 80
        Me.txtTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblTreinamento
        '
        Me.lblTreinamento.AutoSize = True
        Me.lblTreinamento.Location = New System.Drawing.Point(29, 63)
        Me.lblTreinamento.Name = "lblTreinamento"
        Me.lblTreinamento.Size = New System.Drawing.Size(69, 13)
        Me.lblTreinamento.TabIndex = 79
        Me.lblTreinamento.Text = "Treinamento:"
        '
        'chkTodosTiposTreinamentos
        '
        Me.chkTodosTiposTreinamentos.AutoSize = True
        Me.chkTodosTiposTreinamentos.Checked = True
        Me.chkTodosTiposTreinamentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosTiposTreinamentos.Location = New System.Drawing.Point(332, 38)
        Me.chkTodosTiposTreinamentos.Name = "chkTodosTiposTreinamentos"
        Me.chkTodosTiposTreinamentos.Size = New System.Drawing.Size(95, 17)
        Me.chkTodosTiposTreinamentos.TabIndex = 78
        Me.chkTodosTiposTreinamentos.Text = "Todos os tipos"
        Me.chkTodosTiposTreinamentos.UseVisualStyleBackColor = True
        '
        'cmdTipoTreinamento
        '
        Me.cmdTipoTreinamento.Enabled = False
        Me.cmdTipoTreinamento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdTipoTreinamento.Location = New System.Drawing.Point(304, 37)
        Me.cmdTipoTreinamento.Name = "cmdTipoTreinamento"
        Me.cmdTipoTreinamento.Size = New System.Drawing.Size(22, 23)
        Me.cmdTipoTreinamento.TabIndex = 77
        Me.cmdTipoTreinamento.UseVisualStyleBackColor = True
        '
        'txtTipoTreinamento
        '
        Me.txtTipoTreinamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTipoTreinamento.Enabled = False
        Me.txtTipoTreinamento.Location = New System.Drawing.Point(99, 38)
        Me.txtTipoTreinamento.Name = "txtTipoTreinamento"
        Me.txtTipoTreinamento.ReadOnly = True
        Me.txtTipoTreinamento.Size = New System.Drawing.Size(203, 20)
        Me.txtTipoTreinamento.TabIndex = 76
        Me.txtTipoTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblTipoTreinamento
        '
        Me.lblTipoTreinamento.AutoSize = True
        Me.lblTipoTreinamento.Location = New System.Drawing.Point(9, 40)
        Me.lblTipoTreinamento.Name = "lblTipoTreinamento"
        Me.lblTipoTreinamento.Size = New System.Drawing.Size(89, 13)
        Me.lblTipoTreinamento.TabIndex = 75
        Me.lblTipoTreinamento.Text = "Tipo treinamento:"
        '
        'chkTodasEmpresas
        '
        Me.chkTodasEmpresas.AutoSize = True
        Me.chkTodasEmpresas.Checked = True
        Me.chkTodasEmpresas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasEmpresas.Location = New System.Drawing.Point(332, 15)
        Me.chkTodasEmpresas.Name = "chkTodasEmpresas"
        Me.chkTodasEmpresas.Size = New System.Drawing.Size(118, 17)
        Me.chkTodasEmpresas.TabIndex = 74
        Me.chkTodasEmpresas.Text = "Todas as empresas"
        Me.chkTodasEmpresas.UseVisualStyleBackColor = True
        '
        'cmdEmpresa
        '
        Me.cmdEmpresa.Enabled = False
        Me.cmdEmpresa.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdEmpresa.Location = New System.Drawing.Point(304, 13)
        Me.cmdEmpresa.Name = "cmdEmpresa"
        Me.cmdEmpresa.Size = New System.Drawing.Size(22, 23)
        Me.cmdEmpresa.TabIndex = 73
        Me.cmdEmpresa.UseVisualStyleBackColor = True
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Location = New System.Drawing.Point(99, 15)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(203, 20)
        Me.txtEmpresa.TabIndex = 72
        Me.txtEmpresa.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(47, 17)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 71
        Me.lblEmpresa.Text = "Empresa:"
        '
        'chkMostrarFuncionarios
        '
        Me.chkMostrarFuncionarios.AutoSize = True
        Me.chkMostrarFuncionarios.Location = New System.Drawing.Point(99, 111)
        Me.chkMostrarFuncionarios.Name = "chkMostrarFuncionarios"
        Me.chkMostrarFuncionarios.Size = New System.Drawing.Size(124, 17)
        Me.chkMostrarFuncionarios.TabIndex = 88
        Me.chkMostrarFuncionarios.Text = "Mostrar Funcionários"
        Me.chkMostrarFuncionarios.UseVisualStyleBackColor = True
        '
        'frmRelTreinamentoAnalitico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 149)
        Me.Name = "frmRelTreinamentoAnalitico"
        Me.Text = "Relatório de Treinamento Analítico"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.epRelatorio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents epRelatorio As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkMostrarFuncionarios As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodasDatas As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDataFinal As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents chkTodasEmpresas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEmpresa As System.Windows.Forms.Button
    Friend WithEvents txtEmpresa As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
End Class
