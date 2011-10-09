<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssocNRArtigo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraComando = New System.Windows.Forms.GroupBox()
        Me.cmdGravar = New System.Windows.Forms.Button()
        Me.cmdSair = New System.Windows.Forms.Button()
        Me.grpGrid = New System.Windows.Forms.GroupBox()
        Me.dgvArtigos = New System.Windows.Forms.DataGridView()
        Me.fraComando.SuspendLayout()
        Me.grpGrid.SuspendLayout()
        CType(Me.dgvArtigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraComando
        '
        Me.fraComando.Controls.Add(Me.cmdGravar)
        Me.fraComando.Controls.Add(Me.cmdSair)
        Me.fraComando.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComando.Location = New System.Drawing.Point(621, 0)
        Me.fraComando.Name = "fraComando"
        Me.fraComando.Size = New System.Drawing.Size(92, 398)
        Me.fraComando.TabIndex = 45
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
        'grpGrid
        '
        Me.grpGrid.Controls.Add(Me.dgvArtigos)
        Me.grpGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpGrid.Location = New System.Drawing.Point(0, 0)
        Me.grpGrid.Name = "grpGrid"
        Me.grpGrid.Size = New System.Drawing.Size(621, 398)
        Me.grpGrid.TabIndex = 46
        Me.grpGrid.TabStop = False
        '
        'dgvArtigos
        '
        Me.dgvArtigos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArtigos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvArtigos.Location = New System.Drawing.Point(3, 16)
        Me.dgvArtigos.Name = "dgvArtigos"
        Me.dgvArtigos.RowHeadersWidth = 20
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvArtigos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvArtigos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArtigos.Size = New System.Drawing.Size(615, 379)
        Me.dgvArtigos.TabIndex = 1
        '
        'frmAssocNRArtigo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpGrid)
        Me.Controls.Add(Me.fraComando)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssocNRArtigo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Associar artigos à NR"
        Me.fraComando.ResumeLayout(False)
        Me.grpGrid.ResumeLayout(False)
        CType(Me.dgvArtigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraComando As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents grpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgvArtigos As System.Windows.Forms.DataGridView
End Class
