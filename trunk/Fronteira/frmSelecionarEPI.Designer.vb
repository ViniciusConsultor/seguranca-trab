<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelecionarEPI
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
        Me.fraLegenda = New System.Windows.Forms.GroupBox
        Me.cmdIncluir = New System.Windows.Forms.Button
        Me.cmdSelecionarFuncionario = New System.Windows.Forms.Button
        Me.txtEPI = New DSTextBox.DSTextBox
        Me.fraParticipantes = New System.Windows.Forms.GroupBox
        Me.cmdFiltrar = New System.Windows.Forms.Button
        Me.chkFiltrar = New System.Windows.Forms.CheckBox
        Me.fraFiltro = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.dgvEPI = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDataEntrega = New System.Windows.Forms.Label
        Me.dtEntrega = New System.Windows.Forms.DateTimePicker
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.cmdMarcarTodos = New System.Windows.Forms.Button
        Me.fraLegenda.SuspendLayout()
        Me.fraParticipantes.SuspendLayout()
        Me.fraFiltro.SuspendLayout()
        CType(Me.dgvEPI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraLegenda
        '
        Me.fraLegenda.Controls.Add(Me.cmdIncluir)
        Me.fraLegenda.Controls.Add(Me.cmdSelecionarFuncionario)
        Me.fraLegenda.Controls.Add(Me.txtEPI)
        Me.fraLegenda.Location = New System.Drawing.Point(110, 253)
        Me.fraLegenda.Name = "fraLegenda"
        Me.fraLegenda.Size = New System.Drawing.Size(364, 41)
        Me.fraLegenda.TabIndex = 10
        Me.fraLegenda.TabStop = False
        Me.fraLegenda.Text = "Selecionar EPI avulsa"
        '
        'cmdIncluir
        '
        Me.cmdIncluir.Enabled = False
        Me.cmdIncluir.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdIncluir.Location = New System.Drawing.Point(312, 15)
        Me.cmdIncluir.Name = "cmdIncluir"
        Me.cmdIncluir.Size = New System.Drawing.Size(23, 22)
        Me.cmdIncluir.TabIndex = 7
        Me.cmdIncluir.UseVisualStyleBackColor = True
        '
        'cmdSelecionarFuncionario
        '
        Me.cmdSelecionarFuncionario.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarFuncionario.Location = New System.Drawing.Point(335, 15)
        Me.cmdSelecionarFuncionario.Name = "cmdSelecionarFuncionario"
        Me.cmdSelecionarFuncionario.Size = New System.Drawing.Size(23, 22)
        Me.cmdSelecionarFuncionario.TabIndex = 6
        Me.cmdSelecionarFuncionario.UseVisualStyleBackColor = True
        '
        'txtEPI
        '
        Me.txtEPI.Location = New System.Drawing.Point(3, 16)
        Me.txtEPI.MaxLength = 50
        Me.txtEPI.Name = "txtEPI"
        Me.txtEPI.Size = New System.Drawing.Size(307, 20)
        Me.txtEPI.TabIndex = 2
        Me.txtEPI.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'fraParticipantes
        '
        Me.fraParticipantes.Controls.Add(Me.cmdFiltrar)
        Me.fraParticipantes.Controls.Add(Me.chkFiltrar)
        Me.fraParticipantes.Controls.Add(Me.fraFiltro)
        Me.fraParticipantes.Controls.Add(Me.dgvEPI)
        Me.fraParticipantes.Dock = System.Windows.Forms.DockStyle.Top
        Me.fraParticipantes.Location = New System.Drawing.Point(0, 0)
        Me.fraParticipantes.Name = "fraParticipantes"
        Me.fraParticipantes.Size = New System.Drawing.Size(477, 252)
        Me.fraParticipantes.TabIndex = 9
        Me.fraParticipantes.TabStop = False
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.Location = New System.Drawing.Point(414, 19)
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
        Me.chkFiltrar.Size = New System.Drawing.Size(109, 17)
        Me.chkFiltrar.TabIndex = 10
        Me.chkFiltrar.Text = "Somente EPI que"
        Me.chkFiltrar.UseVisualStyleBackColor = False
        '
        'fraFiltro
        '
        Me.fraFiltro.Controls.Add(Me.cboStatus)
        Me.fraFiltro.Enabled = False
        Me.fraFiltro.Location = New System.Drawing.Point(3, 7)
        Me.fraFiltro.Name = "fraFiltro"
        Me.fraFiltro.Size = New System.Drawing.Size(407, 44)
        Me.fraFiltro.TabIndex = 4
        Me.fraFiltro.TabStop = False
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"não foram entregues", "estão atrasados", "estão em dia"})
        Me.cboStatus.Location = New System.Drawing.Point(9, 19)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(390, 21)
        Me.cboStatus.TabIndex = 5
        '
        'dgvEPI
        '
        Me.dgvEPI.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvEPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEPI.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvEPI.Location = New System.Drawing.Point(3, 57)
        Me.dgvEPI.Name = "dgvEPI"
        Me.dgvEPI.Size = New System.Drawing.Size(471, 192)
        Me.dgvEPI.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDataEntrega)
        Me.GroupBox1.Controls.Add(Me.dtEntrega)
        Me.GroupBox1.Controls.Add(Me.cmdSair)
        Me.GroupBox1.Controls.Add(Me.cmdGravar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 292)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 44)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'lblDataEntrega
        '
        Me.lblDataEntrega.AutoSize = True
        Me.lblDataEntrega.Location = New System.Drawing.Point(6, 16)
        Me.lblDataEntrega.Name = "lblDataEntrega"
        Me.lblDataEntrega.Size = New System.Drawing.Size(88, 13)
        Me.lblDataEntrega.TabIndex = 3
        Me.lblDataEntrega.Text = "Data de Entrega:"
        '
        'dtEntrega
        '
        Me.dtEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEntrega.Location = New System.Drawing.Point(100, 13)
        Me.dtEntrega.Name = "dtEntrega"
        Me.dtEntrega.Size = New System.Drawing.Size(102, 20)
        Me.dtEntrega.TabIndex = 2
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(395, 13)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(75, 23)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Cancelar"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdGravar
        '
        Me.cmdGravar.Location = New System.Drawing.Point(317, 13)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(75, 23)
        Me.cmdGravar.TabIndex = 0
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = True
        '
        'cmdMarcarTodos
        '
        Me.cmdMarcarTodos.Location = New System.Drawing.Point(4, 266)
        Me.cmdMarcarTodos.Name = "cmdMarcarTodos"
        Me.cmdMarcarTodos.Size = New System.Drawing.Size(101, 23)
        Me.cmdMarcarTodos.TabIndex = 11
        Me.cmdMarcarTodos.Text = "Marcar todos"
        Me.cmdMarcarTodos.UseVisualStyleBackColor = True
        '
        'frmSelecionarEPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 336)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdMarcarTodos)
        Me.Controls.Add(Me.fraLegenda)
        Me.Controls.Add(Me.fraParticipantes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSelecionarEPI"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecionar EPI - Funcionário:"
        Me.fraLegenda.ResumeLayout(False)
        Me.fraLegenda.PerformLayout()
        Me.fraParticipantes.ResumeLayout(False)
        Me.fraParticipantes.PerformLayout()
        Me.fraFiltro.ResumeLayout(False)
        CType(Me.dgvEPI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraLegenda As System.Windows.Forms.GroupBox
    Friend WithEvents cmdIncluir As System.Windows.Forms.Button
    Friend WithEvents cmdSelecionarFuncionario As System.Windows.Forms.Button
    Friend WithEvents txtEPI As DSTextBox.DSTextBox
    Friend WithEvents fraParticipantes As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents chkFiltrar As System.Windows.Forms.CheckBox
    Friend WithEvents fraFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dgvEPI As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents cmdMarcarTodos As System.Windows.Forms.Button
    Friend WithEvents lblDataEntrega As System.Windows.Forms.Label
    Friend WithEvents dtEntrega As System.Windows.Forms.DateTimePicker
End Class
