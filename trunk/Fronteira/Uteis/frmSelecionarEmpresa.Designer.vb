<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelecionarEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelecionarEmpresa))
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdSelecionar = New System.Windows.Forms.Button
        Me.dgvEmpresa = New System.Windows.Forms.DataGridView
        Me.txtEmpresa = New DSTextBox.DSTextBox
        Me.txtSigla = New DSTextBox.DSTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSigla = New System.Windows.Forms.Label
        Me.fraGeral.SuspendLayout()
        CType(Me.dgvEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.cmdCancelar)
        Me.fraGeral.Controls.Add(Me.cmdSelecionar)
        Me.fraGeral.Controls.Add(Me.dgvEmpresa)
        Me.fraGeral.Controls.Add(Me.txtEmpresa)
        Me.fraGeral.Controls.Add(Me.txtSigla)
        Me.fraGeral.Controls.Add(Me.Label1)
        Me.fraGeral.Controls.Add(Me.lblSigla)
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(326, 263)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(239, 234)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdSelecionar
        '
        Me.cmdSelecionar.Location = New System.Drawing.Point(158, 234)
        Me.cmdSelecionar.Name = "cmdSelecionar"
        Me.cmdSelecionar.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelecionar.TabIndex = 12
        Me.cmdSelecionar.Text = "Selecionar"
        Me.cmdSelecionar.UseVisualStyleBackColor = True
        '
        'dgvEmpresa
        '
        Me.dgvEmpresa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpresa.Location = New System.Drawing.Point(12, 38)
        Me.dgvEmpresa.Name = "dgvEmpresa"
        Me.dgvEmpresa.Size = New System.Drawing.Size(302, 190)
        Me.dgvEmpresa.TabIndex = 11
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(166, 12)
        Me.txtEmpresa.MaxLength = 50
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(148, 20)
        Me.txtEmpresa.TabIndex = 9
        Me.txtEmpresa.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'txtSigla
        '
        Me.txtSigla.Location = New System.Drawing.Point(44, 12)
        Me.txtSigla.MaxLength = 5
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.Size = New System.Drawing.Size(59, 20)
        Me.txtSigla.TabIndex = 7
        Me.txtSigla.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(109, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Empresa:"
        '
        'lblSigla
        '
        Me.lblSigla.AutoSize = True
        Me.lblSigla.Location = New System.Drawing.Point(9, 13)
        Me.lblSigla.Name = "lblSigla"
        Me.lblSigla.Size = New System.Drawing.Size(33, 13)
        Me.lblSigla.TabIndex = 10
        Me.lblSigla.Text = "Sigla:"
        '
        'frmSelecionarEmpresa
        '
        Me.AcceptButton = Me.cmdSelecionar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 263)
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmSelecionarEmpresa"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SegTrab - Selecionar uma empresa"
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        CType(Me.dgvEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEmpresa As System.Windows.Forms.DataGridView
    Friend WithEvents txtEmpresa As DSTextBox.DSTextBox
    Friend WithEvents txtSigla As DSTextBox.DSTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSigla As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdSelecionar As System.Windows.Forms.Button
End Class
