<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssocNR
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
        Me.fraComando = New System.Windows.Forms.GroupBox
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.cmdSair = New System.Windows.Forms.Button
        Me.dgvNR = New System.Windows.Forms.DataGridView
        Me.fraComando.SuspendLayout()
        CType(Me.dgvNR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraComando
        '
        Me.fraComando.Controls.Add(Me.cmdGravar)
        Me.fraComando.Controls.Add(Me.cmdSair)
        Me.fraComando.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComando.Location = New System.Drawing.Point(537, 0)
        Me.fraComando.Name = "fraComando"
        Me.fraComando.Size = New System.Drawing.Size(92, 398)
        Me.fraComando.TabIndex = 2
        Me.fraComando.TabStop = False
        '
        'cmdGravar
        '
        Me.cmdGravar.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdGravar.Location = New System.Drawing.Point(3, 16)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(86, 26)
        Me.cmdGravar.TabIndex = 2
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = True
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 369)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(86, 26)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'dgvNR
        '
        Me.dgvNR.AllowUserToResizeRows = False
        Me.dgvNR.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvNR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNR.Location = New System.Drawing.Point(1, 5)
        Me.dgvNR.Name = "dgvNR"
        Me.dgvNR.Size = New System.Drawing.Size(513, 390)
        Me.dgvNR.TabIndex = 44
        '
        'frmAssocNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvNR)
        Me.Controls.Add(Me.fraComando)
        Me.Name = "frmAssocNR"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração NR por Empresa"
        Me.fraComando.ResumeLayout(False)
        CType(Me.dgvNR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraComando As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents dgvNR As System.Windows.Forms.DataGridView
End Class
