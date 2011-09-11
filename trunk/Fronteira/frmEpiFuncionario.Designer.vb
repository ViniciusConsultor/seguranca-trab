<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEpiFuncionario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEpiFuncionario))
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.fraEquipamentos = New System.Windows.Forms.GroupBox
        Me.cmdDevolver = New System.Windows.Forms.Button
        Me.cmdAdicionarEPI = New System.Windows.Forms.Button
        Me.cmdExcluirEPI = New System.Windows.Forms.Button
        Me.dgvEquipamentos = New System.Windows.Forms.DataGridView
        Me.fraFuncionario = New System.Windows.Forms.GroupBox
        Me.cmdImpressao = New System.Windows.Forms.Button
        Me.txtFuncionario = New DSTextBox.DSTextBox
        Me.lblFuncionario = New System.Windows.Forms.Label
        Me.cmdSelecionarFuncionario = New System.Windows.Forms.Button
        Me.fraComando = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.ttEpiFunc = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraGeral.SuspendLayout()
        Me.fraEquipamentos.SuspendLayout()
        CType(Me.dgvEquipamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraFuncionario.SuspendLayout()
        Me.fraComando.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.fraEquipamentos)
        Me.fraGeral.Controls.Add(Me.fraFuncionario)
        Me.fraGeral.Location = New System.Drawing.Point(3, -3)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(521, 403)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'fraEquipamentos
        '
        Me.fraEquipamentos.Controls.Add(Me.cmdDevolver)
        Me.fraEquipamentos.Controls.Add(Me.cmdAdicionarEPI)
        Me.fraEquipamentos.Controls.Add(Me.cmdExcluirEPI)
        Me.fraEquipamentos.Controls.Add(Me.dgvEquipamentos)
        Me.fraEquipamentos.Location = New System.Drawing.Point(8, 56)
        Me.fraEquipamentos.Name = "fraEquipamentos"
        Me.fraEquipamentos.Size = New System.Drawing.Size(507, 340)
        Me.fraEquipamentos.TabIndex = 7
        Me.fraEquipamentos.TabStop = False
        Me.fraEquipamentos.Text = "Equipamentos"
        '
        'cmdDevolver
        '
        Me.cmdDevolver.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdDevolver.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDevolver.Enabled = False
        Me.cmdDevolver.Image = CType(resources.GetObject("cmdDevolver.Image"), System.Drawing.Image)
        Me.cmdDevolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDevolver.Location = New System.Drawing.Point(458, -1)
        Me.cmdDevolver.Name = "cmdDevolver"
        Me.cmdDevolver.Size = New System.Drawing.Size(21, 19)
        Me.cmdDevolver.TabIndex = 46
        Me.cmdDevolver.Tag = ""
        Me.cmdDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttEpiFunc.SetToolTip(Me.cmdDevolver, "Devolver EPI")
        Me.cmdDevolver.UseVisualStyleBackColor = False
        '
        'cmdAdicionarEPI
        '
        Me.cmdAdicionarEPI.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarEPI.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdicionarEPI.Enabled = False
        Me.cmdAdicionarEPI.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarEPI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarEPI.Location = New System.Drawing.Point(437, -1)
        Me.cmdAdicionarEPI.Name = "cmdAdicionarEPI"
        Me.cmdAdicionarEPI.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarEPI.TabIndex = 44
        Me.cmdAdicionarEPI.Tag = ""
        Me.cmdAdicionarEPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttEpiFunc.SetToolTip(Me.cmdAdicionarEPI, "Entregar EPI")
        Me.cmdAdicionarEPI.UseVisualStyleBackColor = False
        '
        'cmdExcluirEPI
        '
        Me.cmdExcluirEPI.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirEPI.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcluirEPI.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirEPI.Location = New System.Drawing.Point(480, -1)
        Me.cmdExcluirEPI.Name = "cmdExcluirEPI"
        Me.cmdExcluirEPI.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirEPI.TabIndex = 45
        Me.cmdExcluirEPI.Tag = ""
        Me.cmdExcluirEPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttEpiFunc.SetToolTip(Me.cmdExcluirEPI, "Inativar EPI")
        Me.cmdExcluirEPI.UseVisualStyleBackColor = False
        '
        'dgvEquipamentos
        '
        Me.dgvEquipamentos.AllowUserToResizeRows = False
        Me.dgvEquipamentos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvEquipamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipamentos.Location = New System.Drawing.Point(6, 24)
        Me.dgvEquipamentos.Name = "dgvEquipamentos"
        Me.dgvEquipamentos.Size = New System.Drawing.Size(495, 310)
        Me.dgvEquipamentos.TabIndex = 43
        '
        'fraFuncionario
        '
        Me.fraFuncionario.Controls.Add(Me.cmdImpressao)
        Me.fraFuncionario.Controls.Add(Me.txtFuncionario)
        Me.fraFuncionario.Controls.Add(Me.lblFuncionario)
        Me.fraFuncionario.Controls.Add(Me.cmdSelecionarFuncionario)
        Me.fraFuncionario.Location = New System.Drawing.Point(8, 8)
        Me.fraFuncionario.Name = "fraFuncionario"
        Me.fraFuncionario.Size = New System.Drawing.Size(507, 44)
        Me.fraFuncionario.TabIndex = 6
        Me.fraFuncionario.TabStop = False
        '
        'cmdImpressao
        '
        Me.cmdImpressao.Image = CType(resources.GetObject("cmdImpressao.Image"), System.Drawing.Image)
        Me.cmdImpressao.Location = New System.Drawing.Point(477, 13)
        Me.cmdImpressao.Name = "cmdImpressao"
        Me.cmdImpressao.Size = New System.Drawing.Size(24, 25)
        Me.cmdImpressao.TabIndex = 61
        Me.cmdImpressao.UseVisualStyleBackColor = True
        '
        'txtFuncionario
        '
        Me.txtFuncionario.Location = New System.Drawing.Point(76, 15)
        Me.txtFuncionario.MaxLength = 50
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.Size = New System.Drawing.Size(369, 20)
        Me.txtFuncionario.TabIndex = 4
        Me.txtFuncionario.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblFuncionario
        '
        Me.lblFuncionario.AutoSize = True
        Me.lblFuncionario.Location = New System.Drawing.Point(6, 19)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(65, 13)
        Me.lblFuncionario.TabIndex = 2
        Me.lblFuncionario.Text = "Funcionário:"
        '
        'cmdSelecionarFuncionario
        '
        Me.cmdSelecionarFuncionario.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncionario.Location = New System.Drawing.Point(451, 13)
        Me.cmdSelecionarFuncionario.Name = "cmdSelecionarFuncionario"
        Me.cmdSelecionarFuncionario.Size = New System.Drawing.Size(24, 25)
        Me.cmdSelecionarFuncionario.TabIndex = 3
        Me.ttEpiFunc.SetToolTip(Me.cmdSelecionarFuncionario, "Selecionar funcionário")
        Me.cmdSelecionarFuncionario.UseVisualStyleBackColor = True
        '
        'fraComando
        '
        Me.fraComando.Controls.Add(Me.cmdSair)
        Me.fraComando.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComando.Location = New System.Drawing.Point(530, 0)
        Me.fraComando.Name = "fraComando"
        Me.fraComando.Size = New System.Drawing.Size(92, 402)
        Me.fraComando.TabIndex = 1
        Me.fraComando.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 373)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(86, 26)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'frmEpiFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 402)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraComando)
        Me.Controls.Add(Me.fraGeral)
        Me.Name = "frmEpiFuncionario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EPI Funcionário"
        Me.fraGeral.ResumeLayout(False)
        Me.fraEquipamentos.ResumeLayout(False)
        CType(Me.dgvEquipamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraFuncionario.ResumeLayout(False)
        Me.fraFuncionario.PerformLayout()
        Me.fraComando.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents fraEquipamentos As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmdAdicionarEPI As System.Windows.Forms.Button
    Protected Friend WithEvents cmdExcluirEPI As System.Windows.Forms.Button
    Friend WithEvents dgvEquipamentos As System.Windows.Forms.DataGridView
    Friend WithEvents fraFuncionario As System.Windows.Forms.GroupBox
    Friend WithEvents txtFuncionario As DSTextBox.DSTextBox
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents cmdSelecionarFuncionario As System.Windows.Forms.Button
    Friend WithEvents fraComando As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents ttEpiFunc As System.Windows.Forms.ToolTip
    Protected Friend WithEvents cmdDevolver As System.Windows.Forms.Button
    Friend WithEvents cmdImpressao As System.Windows.Forms.Button
End Class
