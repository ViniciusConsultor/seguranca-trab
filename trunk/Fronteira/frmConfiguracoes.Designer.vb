<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracoes
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
        Me.components = New System.ComponentModel.Container
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.fraCmd = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.fraNR = New System.Windows.Forms.GroupBox
        Me.lblMascara = New System.Windows.Forms.Label
        Me.txtMascara = New System.Windows.Forms.TextBox
        Me.ttConfig = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraGeral.SuspendLayout()
        Me.fraCmd.SuspendLayout()
        Me.fraNR.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.fraNR)
        Me.fraGeral.Location = New System.Drawing.Point(1, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(328, 193)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'fraCmd
        '
        Me.fraCmd.Controls.Add(Me.cmdSair)
        Me.fraCmd.Controls.Add(Me.cmdOK)
        Me.fraCmd.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraCmd.Location = New System.Drawing.Point(335, 0)
        Me.fraCmd.Name = "fraCmd"
        Me.fraCmd.Size = New System.Drawing.Size(86, 193)
        Me.fraCmd.TabIndex = 1
        Me.fraCmd.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(6, 160)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(75, 27)
        Me.cmdSair.TabIndex = 4
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(6, 12)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 27)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'fraNR
        '
        Me.fraNR.Controls.Add(Me.txtMascara)
        Me.fraNR.Controls.Add(Me.lblMascara)
        Me.fraNR.Location = New System.Drawing.Point(6, 8)
        Me.fraNR.Name = "fraNR"
        Me.fraNR.Size = New System.Drawing.Size(316, 51)
        Me.fraNR.TabIndex = 0
        Me.fraNR.TabStop = False
        Me.fraNR.Text = "NR"
        '
        'lblMascara
        '
        Me.lblMascara.AutoSize = True
        Me.lblMascara.Location = New System.Drawing.Point(5, 22)
        Me.lblMascara.Name = "lblMascara"
        Me.lblMascara.Size = New System.Drawing.Size(141, 13)
        Me.lblMascara.TabIndex = 0
        Me.lblMascara.Text = "Máscara para Artigos de NR"
        '
        'txtMascara
        '
        Me.txtMascara.Location = New System.Drawing.Point(152, 19)
        Me.txtMascara.Name = "txtMascara"
        Me.txtMascara.Size = New System.Drawing.Size(158, 20)
        Me.txtMascara.TabIndex = 1
        Me.ttConfig.SetToolTip(Me.txtMascara, "Preencha apenas com caractere 9 e pontos")
        '
        'frmConfiguracoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 193)
        Me.Controls.Add(Me.fraCmd)
        Me.Controls.Add(Me.fraGeral)
        Me.Name = "frmConfiguracoes"
        Me.Text = "Configurações"
        Me.fraGeral.ResumeLayout(False)
        Me.fraCmd.ResumeLayout(False)
        Me.fraNR.ResumeLayout(False)
        Me.fraNR.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents fraCmd As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents fraNR As System.Windows.Forms.GroupBox
    Friend WithEvents txtMascara As System.Windows.Forms.TextBox
    Friend WithEvents lblMascara As System.Windows.Forms.Label
    Friend WithEvents ttConfig As System.Windows.Forms.ToolTip
End Class
