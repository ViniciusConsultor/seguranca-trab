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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistro))
        Me.fraRegistro = New System.Windows.Forms.GroupBox
        Me.txtChaveRegistro = New DSTextBox.DSTextBox
        Me.picRegistrado = New System.Windows.Forms.PictureBox
        Me.btnRegistro = New System.Windows.Forms.Button
        Me.txtContraChave = New DSTextBox.DSTextBox
        Me.lblDescricaoRegistro = New System.Windows.Forms.Label
        Me.picNaoRegistrado = New System.Windows.Forms.PictureBox
        Me.lblMensagem = New System.Windows.Forms.Label
        Me.lblContraChave = New System.Windows.Forms.Label
        Me.fraRegistro.SuspendLayout()
        CType(Me.picRegistrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNaoRegistrado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraRegistro
        '
        Me.fraRegistro.Controls.Add(Me.txtChaveRegistro)
        Me.fraRegistro.Controls.Add(Me.picRegistrado)
        Me.fraRegistro.Controls.Add(Me.btnRegistro)
        Me.fraRegistro.Controls.Add(Me.txtContraChave)
        Me.fraRegistro.Controls.Add(Me.lblDescricaoRegistro)
        Me.fraRegistro.Controls.Add(Me.picNaoRegistrado)
        Me.fraRegistro.Controls.Add(Me.lblMensagem)
        Me.fraRegistro.Controls.Add(Me.lblContraChave)
        Me.fraRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraRegistro.Location = New System.Drawing.Point(0, 0)
        Me.fraRegistro.Name = "fraRegistro"
        Me.fraRegistro.Size = New System.Drawing.Size(405, 121)
        Me.fraRegistro.TabIndex = 0
        Me.fraRegistro.TabStop = False
        '
        'txtChaveRegistro
        '
        Me.txtChaveRegistro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtChaveRegistro.Location = New System.Drawing.Point(149, 15)
        Me.txtChaveRegistro.Name = "txtChaveRegistro"
        Me.txtChaveRegistro.ReadOnly = True
        Me.txtChaveRegistro.Size = New System.Drawing.Size(245, 20)
        Me.txtChaveRegistro.TabIndex = 9
        Me.txtChaveRegistro.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'picRegistrado
        '
        Me.picRegistrado.Image = CType(resources.GetObject("picRegistrado.Image"), System.Drawing.Image)
        Me.picRegistrado.Location = New System.Drawing.Point(17, 65)
        Me.picRegistrado.Name = "picRegistrado"
        Me.picRegistrado.Size = New System.Drawing.Size(47, 50)
        Me.picRegistrado.TabIndex = 3
        Me.picRegistrado.TabStop = False
        '
        'btnRegistro
        '
        Me.btnRegistro.Location = New System.Drawing.Point(319, 74)
        Me.btnRegistro.Name = "btnRegistro"
        Me.btnRegistro.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistro.TabIndex = 2
        Me.btnRegistro.Text = "Registrar"
        Me.btnRegistro.UseVisualStyleBackColor = True
        '
        'txtContraChave
        '
        Me.txtContraChave.Location = New System.Drawing.Point(149, 39)
        Me.txtContraChave.Name = "txtContraChave"
        Me.txtContraChave.Size = New System.Drawing.Size(245, 20)
        Me.txtContraChave.TabIndex = 1
        Me.txtContraChave.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblDescricaoRegistro
        '
        Me.lblDescricaoRegistro.AutoSize = True
        Me.lblDescricaoRegistro.Location = New System.Drawing.Point(14, 18)
        Me.lblDescricaoRegistro.Name = "lblDescricaoRegistro"
        Me.lblDescricaoRegistro.Size = New System.Drawing.Size(49, 13)
        Me.lblDescricaoRegistro.TabIndex = 0
        Me.lblDescricaoRegistro.Text = "Registro:"
        '
        'picNaoRegistrado
        '
        Me.picNaoRegistrado.Image = CType(resources.GetObject("picNaoRegistrado.Image"), System.Drawing.Image)
        Me.picNaoRegistrado.Location = New System.Drawing.Point(16, 65)
        Me.picNaoRegistrado.Name = "picNaoRegistrado"
        Me.picNaoRegistrado.Size = New System.Drawing.Size(47, 50)
        Me.picNaoRegistrado.TabIndex = 5
        Me.picNaoRegistrado.TabStop = False
        '
        'lblMensagem
        '
        Me.lblMensagem.AutoSize = True
        Me.lblMensagem.Location = New System.Drawing.Point(79, 80)
        Me.lblMensagem.Name = "lblMensagem"
        Me.lblMensagem.Size = New System.Drawing.Size(69, 13)
        Me.lblMensagem.TabIndex = 8
        Me.lblMensagem.Text = "lblMensagem"
        '
        'lblContraChave
        '
        Me.lblContraChave.AutoSize = True
        Me.lblContraChave.Location = New System.Drawing.Point(14, 42)
        Me.lblContraChave.Name = "lblContraChave"
        Me.lblContraChave.Size = New System.Drawing.Size(129, 13)
        Me.lblContraChave.TabIndex = 7
        Me.lblContraChave.Text = "Insira a chave de registro:"
        '
        'frmRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 121)
        Me.Controls.Add(Me.fraRegistro)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistro"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro"
        Me.fraRegistro.ResumeLayout(False)
        Me.fraRegistro.PerformLayout()
        CType(Me.picRegistrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNaoRegistrado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraRegistro As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescricaoRegistro As System.Windows.Forms.Label
    Friend WithEvents btnRegistro As System.Windows.Forms.Button
    Friend WithEvents txtContraChave As DSTextBox.DSTextBox
    Friend WithEvents picRegistrado As System.Windows.Forms.PictureBox
    Friend WithEvents picNaoRegistrado As System.Windows.Forms.PictureBox
    Friend WithEvents lblContraChave As System.Windows.Forms.Label
    Friend WithEvents lblMensagem As System.Windows.Forms.Label
    Friend WithEvents txtChaveRegistro As DSTextBox.DSTextBox
End Class
