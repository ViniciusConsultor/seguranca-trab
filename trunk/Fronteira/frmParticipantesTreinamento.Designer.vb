<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParticipantesTreinamento
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdMarcarTodos = New System.Windows.Forms.Button
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdSelecionar = New System.Windows.Forms.Button
        Me.fraParticipantes = New System.Windows.Forms.GroupBox
        Me.cmdFiltrar = New System.Windows.Forms.Button
        Me.chkFiltrar = New System.Windows.Forms.CheckBox
        Me.fraFiltro = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.dgvParticipantes = New System.Windows.Forms.DataGridView
        Me.fraLegenda = New System.Windows.Forms.GroupBox
        Me.cmdIncluir = New System.Windows.Forms.Button
        Me.cmdSelecionarFuncionario = New System.Windows.Forms.Button
        Me.txtNome = New DSTextBox.DSTextBox
        Me.GroupBox1.SuspendLayout()
        Me.fraParticipantes.SuspendLayout()
        Me.fraFiltro.SuspendLayout()
        CType(Me.dgvParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraLegenda.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdMarcarTodos)
        Me.GroupBox1.Controls.Add(Me.cmdSair)
        Me.GroupBox1.Controls.Add(Me.cmdSelecionar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 44)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmdMarcarTodos
        '
        Me.cmdMarcarTodos.Location = New System.Drawing.Point(4, 13)
        Me.cmdMarcarTodos.Name = "cmdMarcarTodos"
        Me.cmdMarcarTodos.Size = New System.Drawing.Size(104, 23)
        Me.cmdMarcarTodos.TabIndex = 2
        Me.cmdMarcarTodos.Text = "Marcar todos"
        Me.cmdMarcarTodos.UseVisualStyleBackColor = True
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(307, 13)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(75, 23)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Cancelar"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdSelecionar
        '
        Me.cmdSelecionar.Location = New System.Drawing.Point(229, 13)
        Me.cmdSelecionar.Name = "cmdSelecionar"
        Me.cmdSelecionar.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelecionar.TabIndex = 0
        Me.cmdSelecionar.Text = "Selecionar"
        Me.cmdSelecionar.UseVisualStyleBackColor = True
        '
        'fraParticipantes
        '
        Me.fraParticipantes.Controls.Add(Me.cmdFiltrar)
        Me.fraParticipantes.Controls.Add(Me.chkFiltrar)
        Me.fraParticipantes.Controls.Add(Me.fraFiltro)
        Me.fraParticipantes.Controls.Add(Me.dgvParticipantes)
        Me.fraParticipantes.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraParticipantes.Location = New System.Drawing.Point(0, 0)
        Me.fraParticipantes.Name = "fraParticipantes"
        Me.fraParticipantes.Size = New System.Drawing.Size(389, 252)
        Me.fraParticipantes.TabIndex = 6
        Me.fraParticipantes.TabStop = False
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.Location = New System.Drawing.Point(332, 19)
        Me.cmdFiltrar.Name = "cmdFiltrar"
        Me.cmdFiltrar.Size = New System.Drawing.Size(51, 23)
        Me.cmdFiltrar.TabIndex = 11
        Me.cmdFiltrar.Text = "Filtrar"
        Me.cmdFiltrar.UseVisualStyleBackColor = True
        '
        'chkFiltrar
        '
        Me.chkFiltrar.AutoSize = True
        Me.chkFiltrar.BackColor = System.Drawing.SystemColors.Control
        Me.chkFiltrar.Location = New System.Drawing.Point(9, 9)
        Me.chkFiltrar.Name = "chkFiltrar"
        Me.chkFiltrar.Size = New System.Drawing.Size(149, 17)
        Me.chkFiltrar.TabIndex = 10
        Me.chkFiltrar.Text = "Somente funcionários que"
        Me.chkFiltrar.UseVisualStyleBackColor = False
        '
        'fraFiltro
        '
        Me.fraFiltro.Controls.Add(Me.cboStatus)
        Me.fraFiltro.Enabled = False
        Me.fraFiltro.Location = New System.Drawing.Point(3, 7)
        Me.fraFiltro.Name = "fraFiltro"
        Me.fraFiltro.Size = New System.Drawing.Size(325, 44)
        Me.fraFiltro.TabIndex = 4
        Me.fraFiltro.TabStop = False
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"nunca tiveram treinamento", "tem treinamento atrasado", "estão com treinamento em dia"})
        Me.cboStatus.Location = New System.Drawing.Point(9, 19)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(308, 21)
        Me.cboStatus.TabIndex = 5
        '
        'dgvParticipantes
        '
        Me.dgvParticipantes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParticipantes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvParticipantes.Location = New System.Drawing.Point(3, 57)
        Me.dgvParticipantes.Name = "dgvParticipantes"
        Me.dgvParticipantes.Size = New System.Drawing.Size(383, 192)
        Me.dgvParticipantes.TabIndex = 0
        '
        'fraLegenda
        '
        Me.fraLegenda.Controls.Add(Me.cmdIncluir)
        Me.fraLegenda.Controls.Add(Me.cmdSelecionarFuncionario)
        Me.fraLegenda.Controls.Add(Me.txtNome)
        Me.fraLegenda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.fraLegenda.Location = New System.Drawing.Point(0, 258)
        Me.fraLegenda.Name = "fraLegenda"
        Me.fraLegenda.Size = New System.Drawing.Size(389, 41)
        Me.fraLegenda.TabIndex = 7
        Me.fraLegenda.TabStop = False
        Me.fraLegenda.Text = "Selecionar funcionário avulso"
        '
        'cmdIncluir
        '
        Me.cmdIncluir.Enabled = False
        Me.cmdIncluir.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdIncluir.Location = New System.Drawing.Point(355, 14)
        Me.cmdIncluir.Name = "cmdIncluir"
        Me.cmdIncluir.Size = New System.Drawing.Size(19, 23)
        Me.cmdIncluir.TabIndex = 7
        Me.cmdIncluir.UseVisualStyleBackColor = True
        '
        'cmdSelecionarFuncionario
        '
        Me.cmdSelecionarFuncionario.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncionario.Location = New System.Drawing.Point(330, 14)
        Me.cmdSelecionarFuncionario.Name = "cmdSelecionarFuncionario"
        Me.cmdSelecionarFuncionario.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarFuncionario.TabIndex = 6
        Me.cmdSelecionarFuncionario.UseVisualStyleBackColor = True
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(6, 15)
        Me.txtNome.MaxLength = 50
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(322, 20)
        Me.txtNome.TabIndex = 2
        Me.txtNome.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'frmParticipantesTreinamento
        '
        Me.ClientSize = New System.Drawing.Size(389, 343)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraLegenda)
        Me.Controls.Add(Me.fraParticipantes)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmParticipantesTreinamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecionar Participantes Treinamento"
        Me.GroupBox1.ResumeLayout(False)
        Me.fraParticipantes.ResumeLayout(False)
        Me.fraParticipantes.PerformLayout()
        Me.fraFiltro.ResumeLayout(False)
        CType(Me.dgvParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraLegenda.ResumeLayout(False)
        Me.fraLegenda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMarcarTodos As System.Windows.Forms.Button
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdSelecionar As System.Windows.Forms.Button
    Friend WithEvents fraParticipantes As System.Windows.Forms.GroupBox
    Friend WithEvents dgvParticipantes As System.Windows.Forms.DataGridView
    Friend WithEvents fraLegenda As System.Windows.Forms.GroupBox
    Friend WithEvents txtNome As DSTextBox.DSTextBox
    Friend WithEvents cmdSelecionarFuncionario As System.Windows.Forms.Button
    Friend WithEvents cmdIncluir As System.Windows.Forms.Button
    Friend WithEvents fraFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents chkFiltrar As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFiltrar As System.Windows.Forms.Button
End Class
