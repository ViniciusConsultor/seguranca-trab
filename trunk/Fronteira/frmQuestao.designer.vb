<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestao
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
        Me.fraComandos = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.lblDescLetra = New System.Windows.Forms.Label
        Me.lblLetra = New System.Windows.Forms.Label
        Me.lblDescArtigo = New System.Windows.Forms.Label
        Me.lblArtigo = New System.Windows.Forms.Label
        Me.txtAcao = New System.Windows.Forms.TextBox
        Me.lblAcao = New System.Windows.Forms.Label
        Me.txtQuestao = New System.Windows.Forms.TextBox
        Me.lblQuestao = New System.Windows.Forms.Label
        Me.epQuestao = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.fraComandos.SuspendLayout()
        Me.fraGeral.SuspendLayout()
        CType(Me.epQuestao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraComandos
        '
        Me.fraComandos.Controls.Add(Me.cmdSair)
        Me.fraComandos.Controls.Add(Me.cmdGravar)
        Me.fraComandos.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComandos.Location = New System.Drawing.Point(361, 0)
        Me.fraComandos.Name = "fraComandos"
        Me.fraComandos.Size = New System.Drawing.Size(98, 194)
        Me.fraComandos.TabIndex = 0
        Me.fraComandos.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 164)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(92, 27)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdGravar
        '
        Me.cmdGravar.Location = New System.Drawing.Point(3, 13)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(92, 27)
        Me.cmdGravar.TabIndex = 0
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = True
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.lblDescLetra)
        Me.fraGeral.Controls.Add(Me.lblLetra)
        Me.fraGeral.Controls.Add(Me.lblDescArtigo)
        Me.fraGeral.Controls.Add(Me.lblArtigo)
        Me.fraGeral.Controls.Add(Me.txtAcao)
        Me.fraGeral.Controls.Add(Me.lblAcao)
        Me.fraGeral.Controls.Add(Me.txtQuestao)
        Me.fraGeral.Controls.Add(Me.lblQuestao)
        Me.fraGeral.Location = New System.Drawing.Point(1, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(357, 191)
        Me.fraGeral.TabIndex = 1
        Me.fraGeral.TabStop = False
        '
        'lblDescLetra
        '
        Me.lblDescLetra.AutoSize = True
        Me.lblDescLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescLetra.ForeColor = System.Drawing.Color.Navy
        Me.lblDescLetra.Location = New System.Drawing.Point(220, 16)
        Me.lblDescLetra.Name = "lblDescLetra"
        Me.lblDescLetra.Size = New System.Drawing.Size(36, 13)
        Me.lblDescLetra.TabIndex = 6
        Me.lblDescLetra.Text = "Letra"
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.Location = New System.Drawing.Point(177, 16)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(34, 13)
        Me.lblLetra.TabIndex = 5
        Me.lblLetra.Text = "Letra:"
        '
        'lblDescArtigo
        '
        Me.lblDescArtigo.AutoSize = True
        Me.lblDescArtigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescArtigo.ForeColor = System.Drawing.Color.Navy
        Me.lblDescArtigo.Location = New System.Drawing.Point(62, 16)
        Me.lblDescArtigo.Name = "lblDescArtigo"
        Me.lblDescArtigo.Size = New System.Drawing.Size(40, 13)
        Me.lblDescArtigo.TabIndex = 4
        Me.lblDescArtigo.Text = "Artigo"
        '
        'lblArtigo
        '
        Me.lblArtigo.AutoSize = True
        Me.lblArtigo.Location = New System.Drawing.Point(19, 16)
        Me.lblArtigo.Name = "lblArtigo"
        Me.lblArtigo.Size = New System.Drawing.Size(37, 13)
        Me.lblArtigo.TabIndex = 3
        Me.lblArtigo.Text = "Artigo:"
        '
        'txtAcao
        '
        Me.txtAcao.Location = New System.Drawing.Point(62, 112)
        Me.txtAcao.Multiline = True
        Me.txtAcao.Name = "txtAcao"
        Me.txtAcao.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAcao.Size = New System.Drawing.Size(275, 68)
        Me.txtAcao.TabIndex = 1
        '
        'lblAcao
        '
        Me.lblAcao.AutoSize = True
        Me.lblAcao.Location = New System.Drawing.Point(21, 112)
        Me.lblAcao.Name = "lblAcao"
        Me.lblAcao.Size = New System.Drawing.Size(35, 13)
        Me.lblAcao.TabIndex = 2
        Me.lblAcao.Text = "Ação:"
        '
        'txtQuestao
        '
        Me.txtQuestao.Location = New System.Drawing.Point(62, 38)
        Me.txtQuestao.Multiline = True
        Me.txtQuestao.Name = "txtQuestao"
        Me.txtQuestao.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtQuestao.Size = New System.Drawing.Size(275, 68)
        Me.txtQuestao.TabIndex = 0
        '
        'lblQuestao
        '
        Me.lblQuestao.AutoSize = True
        Me.lblQuestao.Location = New System.Drawing.Point(6, 38)
        Me.lblQuestao.Name = "lblQuestao"
        Me.lblQuestao.Size = New System.Drawing.Size(50, 13)
        Me.lblQuestao.TabIndex = 0
        Me.lblQuestao.Text = "Questão:"
        '
        'epQuestao
        '
        Me.epQuestao.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epQuestao.ContainerControl = Me
        '
        'frmQuestao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 194)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraGeral)
        Me.Controls.Add(Me.fraComandos)
        Me.Name = "frmQuestao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Questão"
        Me.fraComandos.ResumeLayout(False)
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        CType(Me.epQuestao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraComandos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuestao As System.Windows.Forms.TextBox
    Friend WithEvents lblQuestao As System.Windows.Forms.Label
    Friend WithEvents txtAcao As System.Windows.Forms.TextBox
    Friend WithEvents lblAcao As System.Windows.Forms.Label
    Friend WithEvents lblArtigo As System.Windows.Forms.Label
    Friend WithEvents lblDescArtigo As System.Windows.Forms.Label
    Friend WithEvents epQuestao As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDescLetra As System.Windows.Forms.Label
    Friend WithEvents lblLetra As System.Windows.Forms.Label
End Class
