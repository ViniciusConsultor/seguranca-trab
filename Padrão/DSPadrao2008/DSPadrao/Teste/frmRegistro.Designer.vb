<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistro
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
        Me.btnGerarContraChave = New System.Windows.Forms.Button
        Me.txtContraChave = New System.Windows.Forms.TextBox
        Me.txtChave = New System.Windows.Forms.TextBox
        Me.lblContraChave = New System.Windows.Forms.Label
        Me.lblChave = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnGerarContraChave
        '
        Me.btnGerarContraChave.Location = New System.Drawing.Point(144, 32)
        Me.btnGerarContraChave.Name = "btnGerarContraChave"
        Me.btnGerarContraChave.Size = New System.Drawing.Size(123, 23)
        Me.btnGerarContraChave.TabIndex = 3
        Me.btnGerarContraChave.Text = "Gerar contra chave"
        Me.btnGerarContraChave.UseVisualStyleBackColor = True
        '
        'txtContraChave
        '
        Me.txtContraChave.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtContraChave.Location = New System.Drawing.Point(87, 61)
        Me.txtContraChave.Name = "txtContraChave"
        Me.txtContraChave.ReadOnly = True
        Me.txtContraChave.Size = New System.Drawing.Size(180, 20)
        Me.txtContraChave.TabIndex = 5
        '
        'txtChave
        '
        Me.txtChave.Location = New System.Drawing.Point(87, 6)
        Me.txtChave.Name = "txtChave"
        Me.txtChave.Size = New System.Drawing.Size(180, 20)
        Me.txtChave.TabIndex = 2
        '
        'lblContraChave
        '
        Me.lblContraChave.AutoSize = True
        Me.lblContraChave.Location = New System.Drawing.Point(12, 65)
        Me.lblContraChave.Name = "lblContraChave"
        Me.lblContraChave.Size = New System.Drawing.Size(74, 13)
        Me.lblContraChave.TabIndex = 4
        Me.lblContraChave.Text = "Contra chave:"
        '
        'lblChave
        '
        Me.lblChave.AutoSize = True
        Me.lblChave.Location = New System.Drawing.Point(12, 9)
        Me.lblChave.Name = "lblChave"
        Me.lblChave.Size = New System.Drawing.Size(41, 13)
        Me.lblChave.TabIndex = 1
        Me.lblChave.Text = "Chave:"
        '
        'frmRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 94)
        Me.Controls.Add(Me.lblChave)
        Me.Controls.Add(Me.lblContraChave)
        Me.Controls.Add(Me.btnGerarContraChave)
        Me.Controls.Add(Me.txtContraChave)
        Me.Controls.Add(Me.txtChave)
        Me.MaximizeBox = False
        Me.Name = "frmRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Geração chave de registro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGerarContraChave As System.Windows.Forms.Button
    Friend WithEvents txtContraChave As System.Windows.Forms.TextBox
    Friend WithEvents txtChave As System.Windows.Forms.TextBox
    Friend WithEvents lblContraChave As System.Windows.Forms.Label
    Friend WithEvents lblChave As System.Windows.Forms.Label

End Class
