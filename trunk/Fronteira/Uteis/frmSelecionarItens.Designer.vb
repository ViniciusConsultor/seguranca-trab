<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelecionarItens
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
        Me.fraComandos = New System.Windows.Forms.GroupBox
        Me.cmdMarcarTodos = New System.Windows.Forms.Button
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdSelecionar = New System.Windows.Forms.Button
        Me.fraParticipantes = New System.Windows.Forms.GroupBox
        Me.dgvItens = New System.Windows.Forms.DataGridView
        Me.fraGeral.SuspendLayout()
        Me.fraComandos.SuspendLayout()
        Me.fraParticipantes.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.fraComandos)
        Me.fraGeral.Controls.Add(Me.fraParticipantes)
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(392, 256)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'fraComandos
        '
        Me.fraComandos.Controls.Add(Me.cmdMarcarTodos)
        Me.fraComandos.Controls.Add(Me.cmdSair)
        Me.fraComandos.Controls.Add(Me.cmdSelecionar)
        Me.fraComandos.Location = New System.Drawing.Point(4, 207)
        Me.fraComandos.Name = "fraComandos"
        Me.fraComandos.Size = New System.Drawing.Size(385, 43)
        Me.fraComandos.TabIndex = 1
        Me.fraComandos.TabStop = False
        '
        'cmdMarcarTodos
        '
        Me.cmdMarcarTodos.Location = New System.Drawing.Point(5, 13)
        Me.cmdMarcarTodos.Name = "cmdMarcarTodos"
        Me.cmdMarcarTodos.Size = New System.Drawing.Size(104, 23)
        Me.cmdMarcarTodos.TabIndex = 5
        Me.cmdMarcarTodos.Text = "Marcar todos"
        Me.cmdMarcarTodos.UseVisualStyleBackColor = True
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(308, 13)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(75, 23)
        Me.cmdSair.TabIndex = 4
        Me.cmdSair.Text = "Cancelar"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdSelecionar
        '
        Me.cmdSelecionar.Location = New System.Drawing.Point(230, 13)
        Me.cmdSelecionar.Name = "cmdSelecionar"
        Me.cmdSelecionar.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelecionar.TabIndex = 3
        Me.cmdSelecionar.Text = "Confirmar"
        Me.cmdSelecionar.UseVisualStyleBackColor = True
        '
        'fraParticipantes
        '
        Me.fraParticipantes.Controls.Add(Me.dgvItens)
        Me.fraParticipantes.Location = New System.Drawing.Point(4, 8)
        Me.fraParticipantes.Name = "fraParticipantes"
        Me.fraParticipantes.Size = New System.Drawing.Size(383, 200)
        Me.fraParticipantes.TabIndex = 0
        Me.fraParticipantes.TabStop = False
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        Me.dgvItens.AllowUserToResizeRows = False
        Me.dgvItens.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItens.Location = New System.Drawing.Point(3, 16)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.Size = New System.Drawing.Size(377, 181)
        Me.dgvItens.TabIndex = 0
        '
        'frmSelecionarItens
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 256)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmSelecionarItens"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecionar Itens"
        Me.fraGeral.ResumeLayout(False)
        Me.fraComandos.ResumeLayout(False)
        Me.fraParticipantes.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents fraComandos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMarcarTodos As System.Windows.Forms.Button
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdSelecionar As System.Windows.Forms.Button
    Friend WithEvents fraParticipantes As System.Windows.Forms.GroupBox
    Friend WithEvents dgvItens As System.Windows.Forms.DataGridView
End Class
