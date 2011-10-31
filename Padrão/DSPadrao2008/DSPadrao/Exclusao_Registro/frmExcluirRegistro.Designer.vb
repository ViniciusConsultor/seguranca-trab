<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExcluirRegistro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExcluirRegistro))
        Me.btnExcluirRegistro = New System.Windows.Forms.Button()
        Me.grpExclusao = New System.Windows.Forms.GroupBox()
        Me.grpExclusao.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExcluirRegistro
        '
        Me.btnExcluirRegistro.Location = New System.Drawing.Point(81, 19)
        Me.btnExcluirRegistro.Name = "btnExcluirRegistro"
        Me.btnExcluirRegistro.Size = New System.Drawing.Size(135, 23)
        Me.btnExcluirRegistro.TabIndex = 4
        Me.btnExcluirRegistro.Text = "Excluir registro SegTrab"
        Me.btnExcluirRegistro.UseVisualStyleBackColor = True
        '
        'grpExclusao
        '
        Me.grpExclusao.Controls.Add(Me.btnExcluirRegistro)
        Me.grpExclusao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpExclusao.Location = New System.Drawing.Point(0, 0)
        Me.grpExclusao.Name = "grpExclusao"
        Me.grpExclusao.Size = New System.Drawing.Size(284, 60)
        Me.grpExclusao.TabIndex = 5
        Me.grpExclusao.TabStop = False
        '
        'frmExcluirRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 60)
        Me.Controls.Add(Me.grpExclusao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmExcluirRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exclusão Registro SegTrab"
        Me.grpExclusao.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExcluirRegistro As System.Windows.Forms.Button
    Friend WithEvents grpExclusao As System.Windows.Forms.GroupBox
End Class
