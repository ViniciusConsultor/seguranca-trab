<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTreinamento
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
        Me.tbcEPI = New System.Windows.Forms.TabControl
        Me.tbpPrincipal = New System.Windows.Forms.TabPage
        Me.cmdSelecionarTreinamento = New System.Windows.Forms.Button
        Me.fraPrincipal = New System.Windows.Forms.GroupBox
        Me.lblHoras = New System.Windows.Forms.Label
        Me.txtCargaHoraria = New System.Windows.Forms.MaskedTextBox
        Me.lblCargaHoraria = New System.Windows.Forms.Label
        Me.chkPadrao = New System.Windows.Forms.CheckBox
        Me.txtValidade = New DSTextBox.DSTextBox
        Me.lblMeses = New System.Windows.Forms.Label
        Me.lblValidade = New System.Windows.Forms.Label
        Me.txtTreinamento = New DSTextBox.DSTextBox
        Me.lblTreinamento = New System.Windows.Forms.Label
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcEPI.SuspendLayout()
        Me.tbpPrincipal.SuspendLayout()
        Me.fraPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.tbcEPI)
        Me.fraGeral.Size = New System.Drawing.Size(426, 179)
        '
        'tbcEPI
        '
        Me.tbcEPI.Controls.Add(Me.tbpPrincipal)
        Me.tbcEPI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcEPI.Location = New System.Drawing.Point(3, 16)
        Me.tbcEPI.Name = "tbcEPI"
        Me.tbcEPI.SelectedIndex = 0
        Me.tbcEPI.Size = New System.Drawing.Size(420, 160)
        Me.tbcEPI.TabIndex = 40
        '
        'tbpPrincipal
        '
        Me.tbpPrincipal.Controls.Add(Me.cmdSelecionarTreinamento)
        Me.tbpPrincipal.Controls.Add(Me.fraPrincipal)
        Me.tbpPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tbpPrincipal.Name = "tbpPrincipal"
        Me.tbpPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPrincipal.Size = New System.Drawing.Size(412, 134)
        Me.tbpPrincipal.TabIndex = 0
        Me.tbpPrincipal.Text = "Principal"
        Me.tbpPrincipal.UseVisualStyleBackColor = True
        '
        'cmdSelecionarTreinamento
        '
        Me.cmdSelecionarTreinamento.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarTreinamento.Location = New System.Drawing.Point(351, 17)
        Me.cmdSelecionarTreinamento.Name = "cmdSelecionarTreinamento"
        Me.cmdSelecionarTreinamento.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarTreinamento.TabIndex = 2
        Me.cmdSelecionarTreinamento.UseVisualStyleBackColor = True
        '
        'fraPrincipal
        '
        Me.fraPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.fraPrincipal.Controls.Add(Me.lblHoras)
        Me.fraPrincipal.Controls.Add(Me.txtCargaHoraria)
        Me.fraPrincipal.Controls.Add(Me.lblCargaHoraria)
        Me.fraPrincipal.Controls.Add(Me.chkPadrao)
        Me.fraPrincipal.Controls.Add(Me.txtValidade)
        Me.fraPrincipal.Controls.Add(Me.lblMeses)
        Me.fraPrincipal.Controls.Add(Me.lblValidade)
        Me.fraPrincipal.Controls.Add(Me.txtTreinamento)
        Me.fraPrincipal.Controls.Add(Me.lblTreinamento)
        Me.fraPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.fraPrincipal.Name = "fraPrincipal"
        Me.fraPrincipal.Size = New System.Drawing.Size(406, 128)
        Me.fraPrincipal.TabIndex = 3
        Me.fraPrincipal.TabStop = False
        '
        'lblHoras
        '
        Me.lblHoras.AutoSize = True
        Me.lblHoras.Location = New System.Drawing.Point(181, 65)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(33, 13)
        Me.lblHoras.TabIndex = 62
        Me.lblHoras.Text = "horas"
        '
        'txtCargaHoraria
        '
        Me.txtCargaHoraria.Location = New System.Drawing.Point(75, 62)
        Me.txtCargaHoraria.Mask = "00:00"
        Me.txtCargaHoraria.Name = "txtCargaHoraria"
        Me.txtCargaHoraria.Size = New System.Drawing.Size(100, 20)
        Me.txtCargaHoraria.TabIndex = 61
        Me.txtCargaHoraria.ValidatingType = GetType(Date)
        '
        'lblCargaHoraria
        '
        Me.lblCargaHoraria.AutoSize = True
        Me.lblCargaHoraria.Location = New System.Drawing.Point(0, 65)
        Me.lblCargaHoraria.Name = "lblCargaHoraria"
        Me.lblCargaHoraria.Size = New System.Drawing.Size(75, 13)
        Me.lblCargaHoraria.TabIndex = 59
        Me.lblCargaHoraria.Text = "Carga Horária:"
        '
        'chkPadrao
        '
        Me.chkPadrao.AutoSize = True
        Me.chkPadrao.Location = New System.Drawing.Point(75, 93)
        Me.chkPadrao.Name = "chkPadrao"
        Me.chkPadrao.Size = New System.Drawing.Size(122, 17)
        Me.chkPadrao.TabIndex = 6
        Me.chkPadrao.Text = "Treinamento Padrão"
        Me.chkPadrao.UseVisualStyleBackColor = True
        Me.chkPadrao.Visible = False
        '
        'txtValidade
        '
        Me.txtValidade.Location = New System.Drawing.Point(75, 39)
        Me.txtValidade.MaxLength = 3
        Me.txtValidade.Name = "txtValidade"
        Me.txtValidade.Size = New System.Drawing.Size(100, 20)
        Me.txtValidade.TabIndex = 5
        Me.txtValidade.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Numerico
        '
        'lblMeses
        '
        Me.lblMeses.AutoSize = True
        Me.lblMeses.Location = New System.Drawing.Point(181, 42)
        Me.lblMeses.Name = "lblMeses"
        Me.lblMeses.Size = New System.Drawing.Size(37, 13)
        Me.lblMeses.TabIndex = 4
        Me.lblMeses.Text = "meses"
        '
        'lblValidade
        '
        Me.lblValidade.AutoSize = True
        Me.lblValidade.Location = New System.Drawing.Point(24, 42)
        Me.lblValidade.Name = "lblValidade"
        Me.lblValidade.Size = New System.Drawing.Size(51, 13)
        Me.lblValidade.TabIndex = 3
        Me.lblValidade.Text = "Validade:"
        '
        'txtTreinamento
        '
        Me.txtTreinamento.Location = New System.Drawing.Point(75, 16)
        Me.txtTreinamento.MaxLength = 30
        Me.txtTreinamento.Name = "txtTreinamento"
        Me.txtTreinamento.Size = New System.Drawing.Size(270, 20)
        Me.txtTreinamento.TabIndex = 1
        Me.txtTreinamento.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblTreinamento
        '
        Me.lblTreinamento.AutoSize = True
        Me.lblTreinamento.Location = New System.Drawing.Point(6, 18)
        Me.lblTreinamento.Name = "lblTreinamento"
        Me.lblTreinamento.Size = New System.Drawing.Size(69, 13)
        Me.lblTreinamento.TabIndex = 0
        Me.lblTreinamento.Text = "Treinamento:"
        '
        'frmTreinamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 179)
        Me.Name = "frmTreinamento"
        Me.Text = "Cadastro de Treinamento"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcEPI.ResumeLayout(False)
        Me.tbpPrincipal.ResumeLayout(False)
        Me.fraPrincipal.ResumeLayout(False)
        Me.fraPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcEPI As System.Windows.Forms.TabControl
    Friend WithEvents tbpPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents cmdSelecionarTreinamento As System.Windows.Forms.Button
    Friend WithEvents fraPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents lblHoras As System.Windows.Forms.Label
    Friend WithEvents txtCargaHoraria As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCargaHoraria As System.Windows.Forms.Label
    Friend WithEvents chkPadrao As System.Windows.Forms.CheckBox
    Friend WithEvents txtValidade As DSTextBox.DSTextBox
    Friend WithEvents lblMeses As System.Windows.Forms.Label
    Friend WithEvents lblValidade As System.Windows.Forms.Label
    Friend WithEvents txtTreinamento As DSTextBox.DSTextBox
    Friend WithEvents lblTreinamento As System.Windows.Forms.Label
End Class
