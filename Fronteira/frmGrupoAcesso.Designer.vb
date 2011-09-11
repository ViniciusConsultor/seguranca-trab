<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrupoAcesso
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.fraSelecao = New System.Windows.Forms.GroupBox
        Me.txtDescricao = New DSTextBox.DSTextBox
        Me.lblDescricao = New System.Windows.Forms.Label
        Me.fraDados = New System.Windows.Forms.GroupBox
        Me.dgvGrupoAcesso = New System.Windows.Forms.DataGridView
        Me.cmdSelecionarGrupoAcesso = New System.Windows.Forms.Button
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraSelecao.SuspendLayout()
        Me.fraDados.SuspendLayout()
        CType(Me.dgvGrupoAcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.fraDados)
        Me.fraGeral.Controls.Add(Me.fraSelecao)
        Me.fraGeral.Size = New System.Drawing.Size(495, 339)
        '
        'fraSelecao
        '
        Me.fraSelecao.Controls.Add(Me.txtDescricao)
        Me.fraSelecao.Controls.Add(Me.lblDescricao)
        Me.fraSelecao.Location = New System.Drawing.Point(6, 7)
        Me.fraSelecao.Name = "fraSelecao"
        Me.fraSelecao.Size = New System.Drawing.Size(483, 44)
        Me.fraSelecao.TabIndex = 2
        Me.fraSelecao.TabStop = False
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(83, 14)
        Me.txtDescricao.MaxLength = 30
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(300, 20)
        Me.txtDescricao.TabIndex = 61
        Me.txtDescricao.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(6, 16)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.lblDescricao.TabIndex = 62
        Me.lblDescricao.Text = "Descrição:"
        '
        'fraDados
        '
        Me.fraDados.Controls.Add(Me.dgvGrupoAcesso)
        Me.fraDados.Location = New System.Drawing.Point(6, 51)
        Me.fraDados.Name = "fraDados"
        Me.fraDados.Size = New System.Drawing.Size(483, 285)
        Me.fraDados.TabIndex = 3
        Me.fraDados.TabStop = False
        '
        'dgvGrupoAcesso
        '
        Me.dgvGrupoAcesso.AllowUserToAddRows = False
        Me.dgvGrupoAcesso.AllowUserToDeleteRows = False
        Me.dgvGrupoAcesso.AllowUserToResizeRows = False
        Me.dgvGrupoAcesso.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvGrupoAcesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGrupoAcesso.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGrupoAcesso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGrupoAcesso.Location = New System.Drawing.Point(3, 16)
        Me.dgvGrupoAcesso.MultiSelect = False
        Me.dgvGrupoAcesso.Name = "dgvGrupoAcesso"
        Me.dgvGrupoAcesso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvGrupoAcesso.Size = New System.Drawing.Size(477, 266)
        Me.dgvGrupoAcesso.TabIndex = 0
        '
        'cmdSelecionarGrupoAcesso
        '
        Me.cmdSelecionarGrupoAcesso.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdSelecionarGrupoAcesso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelecionarGrupoAcesso.Location = New System.Drawing.Point(391, 19)
        Me.cmdSelecionarGrupoAcesso.Name = "cmdSelecionarGrupoAcesso"
        Me.cmdSelecionarGrupoAcesso.Size = New System.Drawing.Size(22, 23)
        Me.cmdSelecionarGrupoAcesso.TabIndex = 64
        Me.ttPadrao.SetToolTip(Me.cmdSelecionarGrupoAcesso, "Selecionar grupo de acesso")
        Me.cmdSelecionarGrupoAcesso.UseVisualStyleBackColor = True
        '
        'frmGrupoAcesso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 339)
        Me.Controls.Add(Me.cmdSelecionarGrupoAcesso)
        Me.Name = "frmGrupoAcesso"
        Me.Text = "Grupo de Acesso"
        Me.Controls.SetChildIndex(Me.fraGeral, 0)
        Me.Controls.SetChildIndex(Me.cmdSelecionarGrupoAcesso, 0)
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraSelecao.ResumeLayout(False)
        Me.fraSelecao.PerformLayout()
        Me.fraDados.ResumeLayout(False)
        CType(Me.dgvGrupoAcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraSelecao As System.Windows.Forms.GroupBox
    Friend WithEvents fraDados As System.Windows.Forms.GroupBox
    Friend WithEvents dgvGrupoAcesso As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescricao As DSTextBox.DSTextBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents cmdSelecionarGrupoAcesso As System.Windows.Forms.Button
End Class
