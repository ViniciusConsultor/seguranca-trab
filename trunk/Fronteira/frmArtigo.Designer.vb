<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtigo
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
        Me.txtPenalidade = New System.Windows.Forms.MaskedTextBox
        Me.txtLetra = New System.Windows.Forms.TextBox
        Me.lblLetra = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTexto = New System.Windows.Forms.TextBox
        Me.lblAcao = New System.Windows.Forms.Label
        Me.txtArtigo = New System.Windows.Forms.TextBox
        Me.lblArtigo = New System.Windows.Forms.Label
        Me.fraComandos = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.epArtigo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.fraGeral.SuspendLayout()
        Me.fraComandos.SuspendLayout()
        CType(Me.epArtigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.txtPenalidade)
        Me.fraGeral.Controls.Add(Me.txtLetra)
        Me.fraGeral.Controls.Add(Me.lblLetra)
        Me.fraGeral.Controls.Add(Me.Label1)
        Me.fraGeral.Controls.Add(Me.txtTexto)
        Me.fraGeral.Controls.Add(Me.lblAcao)
        Me.fraGeral.Controls.Add(Me.txtArtigo)
        Me.fraGeral.Controls.Add(Me.lblArtigo)
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(368, 136)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'txtPenalidade
        '
        Me.txtPenalidade.Location = New System.Drawing.Point(71, 110)
        Me.txtPenalidade.Mask = "###.###-#/>?<#"
        Me.txtPenalidade.Name = "txtPenalidade"
        Me.txtPenalidade.Size = New System.Drawing.Size(138, 20)
        Me.txtPenalidade.TabIndex = 7
        '
        'txtLetra
        '
        Me.txtLetra.Location = New System.Drawing.Point(292, 16)
        Me.txtLetra.MaxLength = 3
        Me.txtLetra.Multiline = True
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(54, 20)
        Me.txtLetra.TabIndex = 3
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.Location = New System.Drawing.Point(253, 20)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(34, 13)
        Me.lblLetra.TabIndex = 2
        Me.lblLetra.Text = "Letra:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Penalidade:"
        '
        'txtTexto
        '
        Me.txtTexto.Location = New System.Drawing.Point(71, 38)
        Me.txtTexto.Multiline = True
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTexto.Size = New System.Drawing.Size(275, 68)
        Me.txtTexto.TabIndex = 5
        '
        'lblAcao
        '
        Me.lblAcao.AutoSize = True
        Me.lblAcao.Location = New System.Drawing.Point(32, 42)
        Me.lblAcao.Name = "lblAcao"
        Me.lblAcao.Size = New System.Drawing.Size(37, 13)
        Me.lblAcao.TabIndex = 4
        Me.lblAcao.Text = "Texto:"
        '
        'txtArtigo
        '
        Me.txtArtigo.Location = New System.Drawing.Point(71, 16)
        Me.txtArtigo.MaxLength = 20
        Me.txtArtigo.Multiline = True
        Me.txtArtigo.Name = "txtArtigo"
        Me.txtArtigo.Size = New System.Drawing.Size(131, 20)
        Me.txtArtigo.TabIndex = 1
        '
        'lblArtigo
        '
        Me.lblArtigo.AutoSize = True
        Me.lblArtigo.Location = New System.Drawing.Point(32, 20)
        Me.lblArtigo.Name = "lblArtigo"
        Me.lblArtigo.Size = New System.Drawing.Size(37, 13)
        Me.lblArtigo.TabIndex = 0
        Me.lblArtigo.Text = "Artigo:"
        '
        'fraComandos
        '
        Me.fraComandos.Controls.Add(Me.cmdSair)
        Me.fraComandos.Controls.Add(Me.cmdGravar)
        Me.fraComandos.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComandos.Location = New System.Drawing.Point(373, 0)
        Me.fraComandos.Name = "fraComandos"
        Me.fraComandos.Size = New System.Drawing.Size(98, 136)
        Me.fraComandos.TabIndex = 1
        Me.fraComandos.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 106)
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
        'epArtigo
        '
        Me.epArtigo.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epArtigo.ContainerControl = Me
        '
        'frmArtigo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 136)
        Me.Controls.Add(Me.fraComandos)
        Me.Controls.Add(Me.fraGeral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArtigo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Artigo"
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        Me.fraComandos.ResumeLayout(False)
        CType(Me.epArtigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents lblAcao As System.Windows.Forms.Label
    Friend WithEvents txtArtigo As System.Windows.Forms.TextBox
    Friend WithEvents lblArtigo As System.Windows.Forms.Label
    Friend WithEvents fraComandos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents epArtigo As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtLetra As System.Windows.Forms.TextBox
    Friend WithEvents lblLetra As System.Windows.Forms.Label
    Friend WithEvents txtPenalidade As System.Windows.Forms.MaskedTextBox

End Class
