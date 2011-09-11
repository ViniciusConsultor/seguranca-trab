<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesquisa
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
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.cboCampos = New System.Windows.Forms.ComboBox
        Me.dgvGridResultados = New System.Windows.Forms.DataGridView
        Me.txtCampo = New DSTextBox.DSTextBox
        Me.fraGeral.SuspendLayout()
        CType(Me.dgvGridResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.cboCampos)
        Me.fraGeral.Controls.Add(Me.dgvGridResultados)
        Me.fraGeral.Controls.Add(Me.txtCampo)
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(326, 263)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'cboCampos
        '
        Me.cboCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCampos.FormattingEnabled = True
        Me.cboCampos.Location = New System.Drawing.Point(7, 13)
        Me.cboCampos.Name = "cboCampos"
        Me.cboCampos.Size = New System.Drawing.Size(100, 21)
        Me.cboCampos.TabIndex = 8
        '
        'dgvGridResultados
        '
        Me.dgvGridResultados.AllowUserToAddRows = False
        Me.dgvGridResultados.AllowUserToDeleteRows = False
        Me.dgvGridResultados.AllowUserToResizeRows = False
        Me.dgvGridResultados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvGridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGridResultados.Location = New System.Drawing.Point(6, 40)
        Me.dgvGridResultados.Name = "dgvGridResultados"
        Me.dgvGridResultados.Size = New System.Drawing.Size(314, 217)
        Me.dgvGridResultados.TabIndex = 7
        '
        'txtCampo
        '
        Me.txtCampo.Location = New System.Drawing.Point(113, 13)
        Me.txtCampo.Name = "txtCampo"
        Me.txtCampo.Size = New System.Drawing.Size(207, 20)
        Me.txtCampo.TabIndex = 6
        Me.txtCampo.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'frmPesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 263)
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPesquisa"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPesquisa"
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        CType(Me.dgvGridResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents dgvGridResultados As System.Windows.Forms.DataGridView
    Friend WithEvents txtCampo As DSTextBox.DSTextBox
    Friend WithEvents cboCampos As System.Windows.Forms.ComboBox
End Class
