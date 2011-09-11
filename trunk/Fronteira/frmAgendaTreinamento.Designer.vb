<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgendaTreinamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgendaTreinamento))
        Me.fraDados = New System.Windows.Forms.GroupBox
        Me.txtCargaHoraria = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMinistrante = New DSTextBox.DSTextBox
        Me.lblMinistrante = New System.Windows.Forms.Label
        Me.txtTreinamento = New DSTextBox.DSTextBox
        Me.lblTreinamento = New System.Windows.Forms.Label
        Me.dtpData = New System.Windows.Forms.DateTimePicker
        Me.lblData = New System.Windows.Forms.Label
        Me.txtDescricao = New DSTextBox.DSTextBox
        Me.lblDescricao = New System.Windows.Forms.Label
        Me.fraParticipantes = New System.Windows.Forms.GroupBox
        Me.cmdAdicionarParticipante = New System.Windows.Forms.Button
        Me.cmdExcluirParticipante = New System.Windows.Forms.Button
        Me.dgvParticipantes = New System.Windows.Forms.DataGridView
        Me.cmdSelecionarTreinamento = New System.Windows.Forms.Button
        Me.cmdImpressao = New System.Windows.Forms.Button
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraDados.SuspendLayout()
        Me.fraParticipantes.SuspendLayout()
        CType(Me.dgvParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.cmdSelecionarTreinamento)
        Me.fraGeral.Controls.Add(Me.fraDados)
        Me.fraGeral.Controls.Add(Me.fraParticipantes)
        Me.fraGeral.Size = New System.Drawing.Size(504, 356)
        '
        'fraDados
        '
        Me.fraDados.BackColor = System.Drawing.Color.Transparent
        Me.fraDados.Controls.Add(Me.txtCargaHoraria)
        Me.fraDados.Controls.Add(Me.Label1)
        Me.fraDados.Controls.Add(Me.txtMinistrante)
        Me.fraDados.Controls.Add(Me.lblMinistrante)
        Me.fraDados.Controls.Add(Me.txtTreinamento)
        Me.fraDados.Controls.Add(Me.lblTreinamento)
        Me.fraDados.Controls.Add(Me.dtpData)
        Me.fraDados.Controls.Add(Me.lblData)
        Me.fraDados.Controls.Add(Me.txtDescricao)
        Me.fraDados.Controls.Add(Me.lblDescricao)
        Me.fraDados.Location = New System.Drawing.Point(3, 6)
        Me.fraDados.Name = "fraDados"
        Me.fraDados.Size = New System.Drawing.Size(497, 133)
        Me.fraDados.TabIndex = 1
        Me.fraDados.TabStop = False
        '
        'txtCargaHoraria
        '
        Me.txtCargaHoraria.Location = New System.Drawing.Point(370, 38)
        Me.txtCargaHoraria.Mask = "00:00"
        Me.txtCargaHoraria.Name = "txtCargaHoraria"
        Me.txtCargaHoraria.Size = New System.Drawing.Size(72, 20)
        Me.txtCargaHoraria.TabIndex = 62
        Me.txtCargaHoraria.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(292, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Carga Horária:"
        '
        'txtMinistrante
        '
        Me.txtMinistrante.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMinistrante.Location = New System.Drawing.Point(81, 62)
        Me.txtMinistrante.MaxLength = 50
        Me.txtMinistrante.Name = "txtMinistrante"
        Me.txtMinistrante.Size = New System.Drawing.Size(361, 20)
        Me.txtMinistrante.TabIndex = 56
        Me.txtMinistrante.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblMinistrante
        '
        Me.lblMinistrante.AutoSize = True
        Me.lblMinistrante.Location = New System.Drawing.Point(14, 64)
        Me.lblMinistrante.Name = "lblMinistrante"
        Me.lblMinistrante.Size = New System.Drawing.Size(61, 13)
        Me.lblMinistrante.TabIndex = 55
        Me.lblMinistrante.Text = "Ministrante:"
        '
        'txtTreinamento
        '
        Me.txtTreinamento.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtTreinamento.Location = New System.Drawing.Point(81, 15)
        Me.txtTreinamento.MaxLength = 50
        Me.txtTreinamento.Name = "txtTreinamento"
        Me.txtTreinamento.ReadOnly = True
        Me.txtTreinamento.Size = New System.Drawing.Size(361, 20)
        Me.txtTreinamento.TabIndex = 53
        Me.txtTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblTreinamento
        '
        Me.lblTreinamento.AutoSize = True
        Me.lblTreinamento.Location = New System.Drawing.Point(6, 17)
        Me.lblTreinamento.Name = "lblTreinamento"
        Me.lblTreinamento.Size = New System.Drawing.Size(69, 13)
        Me.lblTreinamento.TabIndex = 52
        Me.lblTreinamento.Text = "Treinamento:"
        '
        'dtpData
        '
        Me.dtpData.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpData.Location = New System.Drawing.Point(81, 39)
        Me.dtpData.Name = "dtpData"
        Me.dtpData.Size = New System.Drawing.Size(127, 20)
        Me.dtpData.TabIndex = 47
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(42, 41)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(33, 13)
        Me.lblData.TabIndex = 46
        Me.lblData.Text = "Data:"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(81, 85)
        Me.txtDescricao.MaxLength = 255
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescricao.Size = New System.Drawing.Size(361, 42)
        Me.txtDescricao.TabIndex = 42
        Me.txtDescricao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(17, 87)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.lblDescricao.TabIndex = 41
        Me.lblDescricao.Text = "Descrição:"
        '
        'fraParticipantes
        '
        Me.fraParticipantes.Controls.Add(Me.cmdAdicionarParticipante)
        Me.fraParticipantes.Controls.Add(Me.cmdExcluirParticipante)
        Me.fraParticipantes.Controls.Add(Me.dgvParticipantes)
        Me.fraParticipantes.Location = New System.Drawing.Point(3, 142)
        Me.fraParticipantes.Name = "fraParticipantes"
        Me.fraParticipantes.Size = New System.Drawing.Size(497, 211)
        Me.fraParticipantes.TabIndex = 2
        Me.fraParticipantes.TabStop = False
        Me.fraParticipantes.Text = "Participantes"
        '
        'cmdAdicionarParticipante
        '
        Me.cmdAdicionarParticipante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAdicionarParticipante.BackColor = System.Drawing.Color.Transparent
        Me.cmdAdicionarParticipante.Enabled = False
        Me.cmdAdicionarParticipante.Image = Global.Fronteira.My.Resources.Resources.Adicionar21
        Me.cmdAdicionarParticipante.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarParticipante.Location = New System.Drawing.Point(449, 0)
        Me.cmdAdicionarParticipante.Name = "cmdAdicionarParticipante"
        Me.cmdAdicionarParticipante.Size = New System.Drawing.Size(21, 19)
        Me.cmdAdicionarParticipante.TabIndex = 44
        Me.cmdAdicionarParticipante.Tag = ""
        Me.cmdAdicionarParticipante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarParticipante.UseVisualStyleBackColor = False
        '
        'cmdExcluirParticipante
        '
        Me.cmdExcluirParticipante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExcluirParticipante.BackColor = System.Drawing.Color.Transparent
        Me.cmdExcluirParticipante.Image = Global.Fronteira.My.Resources.Resources.Excluir
        Me.cmdExcluirParticipante.Location = New System.Drawing.Point(472, 0)
        Me.cmdExcluirParticipante.Name = "cmdExcluirParticipante"
        Me.cmdExcluirParticipante.Size = New System.Drawing.Size(21, 19)
        Me.cmdExcluirParticipante.TabIndex = 45
        Me.cmdExcluirParticipante.Tag = ""
        Me.cmdExcluirParticipante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirParticipante.UseVisualStyleBackColor = False
        '
        'dgvParticipantes
        '
        Me.dgvParticipantes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParticipantes.Location = New System.Drawing.Point(3, 19)
        Me.dgvParticipantes.Name = "dgvParticipantes"
        Me.dgvParticipantes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvParticipantes.Size = New System.Drawing.Size(491, 186)
        Me.dgvParticipantes.TabIndex = 43
        '
        'cmdSelecionarTreinamento
        '
        Me.cmdSelecionarTreinamento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarTreinamento.Location = New System.Drawing.Point(449, 19)
        Me.cmdSelecionarTreinamento.Name = "cmdSelecionarTreinamento"
        Me.cmdSelecionarTreinamento.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarTreinamento.TabIndex = 58
        Me.cmdSelecionarTreinamento.UseVisualStyleBackColor = True
        '
        'cmdImpressao
        '
        Me.cmdImpressao.Image = CType(resources.GetObject("cmdImpressao.Image"), System.Drawing.Image)
        Me.cmdImpressao.Location = New System.Drawing.Point(472, 19)
        Me.cmdImpressao.Name = "cmdImpressao"
        Me.cmdImpressao.Size = New System.Drawing.Size(22, 23)
        Me.cmdImpressao.TabIndex = 60
        Me.ttPadrao.SetToolTip(Me.cmdImpressao, "Imprimir relatório de treinamento")
        Me.cmdImpressao.UseVisualStyleBackColor = True
        '
        'frmAgendaTreinamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 356)
        Me.Controls.Add(Me.cmdImpressao)
        Me.Name = "frmAgendaTreinamento"
        Me.Text = "Agenda de Treinamento"
        Me.Controls.SetChildIndex(Me.fraGeral, 0)
        Me.Controls.SetChildIndex(Me.cmdImpressao, 0)
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraDados.ResumeLayout(False)
        Me.fraDados.PerformLayout()
        Me.fraParticipantes.ResumeLayout(False)
        CType(Me.dgvParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraDados As System.Windows.Forms.GroupBox
    Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents txtDescricao As DSTextBox.DSTextBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents fraParticipantes As System.Windows.Forms.GroupBox
    Friend WithEvents dgvParticipantes As System.Windows.Forms.DataGridView
    Protected Friend WithEvents cmdExcluirParticipante As System.Windows.Forms.Button
    Protected Friend WithEvents cmdAdicionarParticipante As System.Windows.Forms.Button
    Friend WithEvents txtTreinamento As DSTextBox.DSTextBox
    Friend WithEvents lblTreinamento As System.Windows.Forms.Label
    Friend WithEvents txtMinistrante As DSTextBox.DSTextBox
    Friend WithEvents lblMinistrante As System.Windows.Forms.Label
    Friend WithEvents cmdSelecionarTreinamento As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCargaHoraria As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdImpressao As System.Windows.Forms.Button
End Class
