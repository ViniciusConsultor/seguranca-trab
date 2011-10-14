<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelFuncionario
    Inherits DSFronteiraPadrao.frmPadraoRelatorio

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
        Me.components = New System.ComponentModel.Container()
        Me.grpRelatorio = New System.Windows.Forms.GroupBox()
        Me.chkTodosFuncionarios = New System.Windows.Forms.CheckBox()
        Me.cmdFuncionario = New System.Windows.Forms.Button()
        Me.txtFuncionario = New DSTextBox.DSTextBox()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.chkTodasEmpresas = New System.Windows.Forms.CheckBox()
        Me.cmdEmpresa = New System.Windows.Forms.Button()
        Me.txtEmpresa = New DSTextBox.DSTextBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.epPadrao = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpRelatorio.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(456, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(76, 82)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(3, 54)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grpRelatorio)
        Me.GroupBox2.Size = New System.Drawing.Size(456, 82)
        '
        'grpRelatorio
        '
        Me.grpRelatorio.BackColor = System.Drawing.Color.Transparent
        Me.grpRelatorio.Controls.Add(Me.chkTodosFuncionarios)
        Me.grpRelatorio.Controls.Add(Me.cmdFuncionario)
        Me.grpRelatorio.Controls.Add(Me.txtFuncionario)
        Me.grpRelatorio.Controls.Add(Me.lblFuncionario)
        Me.grpRelatorio.Controls.Add(Me.chkTodasEmpresas)
        Me.grpRelatorio.Controls.Add(Me.cmdEmpresa)
        Me.grpRelatorio.Controls.Add(Me.txtEmpresa)
        Me.grpRelatorio.Controls.Add(Me.lblEmpresa)
        Me.grpRelatorio.Location = New System.Drawing.Point(4, 8)
        Me.grpRelatorio.Name = "grpRelatorio"
        Me.grpRelatorio.Size = New System.Drawing.Size(448, 69)
        Me.grpRelatorio.TabIndex = 86
        Me.grpRelatorio.TabStop = False
        '
        'chkTodosFuncionarios
        '
        Me.chkTodosFuncionarios.AutoSize = True
        Me.chkTodosFuncionarios.Checked = True
        Me.chkTodosFuncionarios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosFuncionarios.Location = New System.Drawing.Point(306, 37)
        Me.chkTodosFuncionarios.Name = "chkTodosFuncionarios"
        Me.chkTodosFuncionarios.Size = New System.Drawing.Size(130, 17)
        Me.chkTodosFuncionarios.TabIndex = 74
        Me.chkTodosFuncionarios.Text = "Todos os funcionários"
        Me.chkTodosFuncionarios.UseVisualStyleBackColor = True
        '
        'cmdFuncionario
        '
        Me.cmdFuncionario.Enabled = False
        Me.cmdFuncionario.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdFuncionario.Location = New System.Drawing.Point(278, 36)
        Me.cmdFuncionario.Name = "cmdFuncionario"
        Me.cmdFuncionario.Size = New System.Drawing.Size(22, 23)
        Me.cmdFuncionario.TabIndex = 73
        Me.cmdFuncionario.UseVisualStyleBackColor = True
        '
        'txtFuncionario
        '
        Me.txtFuncionario.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtFuncionario.Enabled = False
        Me.txtFuncionario.Location = New System.Drawing.Point(73, 37)
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.ReadOnly = True
        Me.txtFuncionario.Size = New System.Drawing.Size(203, 20)
        Me.txtFuncionario.TabIndex = 72
        Me.txtFuncionario.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblFuncionario
        '
        Me.lblFuncionario.AutoSize = True
        Me.lblFuncionario.Location = New System.Drawing.Point(7, 39)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(65, 13)
        Me.lblFuncionario.TabIndex = 71
        Me.lblFuncionario.Text = "Funcionário:"
        '
        'chkTodasEmpresas
        '
        Me.chkTodasEmpresas.AutoSize = True
        Me.chkTodasEmpresas.Checked = True
        Me.chkTodasEmpresas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasEmpresas.Location = New System.Drawing.Point(306, 14)
        Me.chkTodasEmpresas.Name = "chkTodasEmpresas"
        Me.chkTodasEmpresas.Size = New System.Drawing.Size(118, 17)
        Me.chkTodasEmpresas.TabIndex = 70
        Me.chkTodasEmpresas.Text = "Todas as empresas"
        Me.chkTodasEmpresas.UseVisualStyleBackColor = True
        '
        'cmdEmpresa
        '
        Me.cmdEmpresa.Enabled = False
        Me.cmdEmpresa.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdEmpresa.Location = New System.Drawing.Point(278, 12)
        Me.cmdEmpresa.Name = "cmdEmpresa"
        Me.cmdEmpresa.Size = New System.Drawing.Size(22, 23)
        Me.cmdEmpresa.TabIndex = 69
        Me.cmdEmpresa.UseVisualStyleBackColor = True
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Location = New System.Drawing.Point(73, 14)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(203, 20)
        Me.txtEmpresa.TabIndex = 68
        Me.txtEmpresa.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(21, 16)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 67
        Me.lblEmpresa.Text = "Empresa:"
        '
        'epPadrao
        '
        Me.epPadrao.ContainerControl = Me
        '
        'frmRelFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 82)
        Me.Name = "frmRelFuncionario"
        Me.Text = "Relatório de Funcionários"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.grpRelatorio.ResumeLayout(False)
        Me.grpRelatorio.PerformLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpRelatorio As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodosFuncionarios As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFuncionario As System.Windows.Forms.Button
    Friend WithEvents txtFuncionario As DSTextBox.DSTextBox
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents chkTodasEmpresas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEmpresa As System.Windows.Forms.Button
    Friend WithEvents txtEmpresa As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents epPadrao As System.Windows.Forms.ErrorProvider
End Class
