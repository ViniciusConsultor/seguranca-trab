<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPadrao
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
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.cmdExcluir = New System.Windows.Forms.Button
        Me.cmdNovo = New System.Windows.Forms.Button
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.epPadrao = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ttPadrao = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraComandos.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraComandos
        '
        Me.fraComandos.BackColor = System.Drawing.SystemColors.Control
        Me.fraComandos.Controls.Add(Me.cmdSair)
        Me.fraComandos.Controls.Add(Me.cmdCancelar)
        Me.fraComandos.Controls.Add(Me.cmdGravar)
        Me.fraComandos.Controls.Add(Me.cmdExcluir)
        Me.fraComandos.Controls.Add(Me.cmdNovo)
        Me.fraComandos.Dock = System.Windows.Forms.DockStyle.Right
        Me.fraComandos.Location = New System.Drawing.Point(382, 0)
        Me.fraComandos.Name = "fraComandos"
        Me.fraComandos.Size = New System.Drawing.Size(98, 252)
        Me.fraComandos.TabIndex = 3
        Me.fraComandos.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 222)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(92, 27)
        Me.cmdSair.TabIndex = 4
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(3, 112)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(92, 27)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Alterar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGravar
        '
        Me.cmdGravar.Location = New System.Drawing.Point(3, 79)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(92, 27)
        Me.cmdGravar.TabIndex = 2
        Me.cmdGravar.Text = "Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = True
        '
        'cmdExcluir
        '
        Me.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluir.Location = New System.Drawing.Point(3, 46)
        Me.cmdExcluir.Name = "cmdExcluir"
        Me.cmdExcluir.Size = New System.Drawing.Size(92, 27)
        Me.cmdExcluir.TabIndex = 1
        Me.cmdExcluir.Text = "Excluir"
        Me.cmdExcluir.UseVisualStyleBackColor = True
        '
        'cmdNovo
        '
        Me.cmdNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNovo.Location = New System.Drawing.Point(3, 13)
        Me.cmdNovo.Name = "cmdNovo"
        Me.cmdNovo.Size = New System.Drawing.Size(92, 27)
        Me.cmdNovo.TabIndex = 0
        Me.cmdNovo.Text = "Novo"
        Me.cmdNovo.UseVisualStyleBackColor = True
        '
        'fraGeral
        '
        Me.fraGeral.BackColor = System.Drawing.SystemColors.Control
        Me.fraGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraGeral.Location = New System.Drawing.Point(0, 0)
        Me.fraGeral.Margin = New System.Windows.Forms.Padding(10)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(382, 252)
        Me.fraGeral.TabIndex = 4
        Me.fraGeral.TabStop = False
        '
        'epPadrao
        '
        Me.epPadrao.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epPadrao.ContainerControl = Me
        '
        'ttPadrao
        '
        Me.ttPadrao.ShowAlways = True
        '
        'frmPadrao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraGeral)
        Me.Controls.Add(Me.fraComandos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmPadrao"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPadrao"
        Me.fraComandos.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents fraComandos As System.Windows.Forms.GroupBox
    Private WithEvents cmdSair As System.Windows.Forms.Button
    Private WithEvents cmdCancelar As System.Windows.Forms.Button
    Private WithEvents cmdGravar As System.Windows.Forms.Button
    Private WithEvents cmdExcluir As System.Windows.Forms.Button
    Private WithEvents cmdNovo As System.Windows.Forms.Button
    Public WithEvents fraGeral As System.Windows.Forms.GroupBox
    Public WithEvents epPadrao As System.Windows.Forms.ErrorProvider
    Public WithEvents ttPadrao As System.Windows.Forms.ToolTip

End Class
