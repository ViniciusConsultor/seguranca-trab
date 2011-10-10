<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelEntregaEPIAnalitico
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkTodosEPI = New System.Windows.Forms.CheckBox()
        Me.cmdEPI = New System.Windows.Forms.Button()
        Me.txtEPI = New DSTextBox.DSTextBox()
        Me.lblEPI = New System.Windows.Forms.Label()
        Me.chkTodasEmpresas = New System.Windows.Forms.CheckBox()
        Me.cmdEmpresa = New System.Windows.Forms.Button()
        Me.txtEmpresa = New DSTextBox.DSTextBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.chkMostrarFuncionarios = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(455, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(76, 100)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(3, 72)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Size = New System.Drawing.Size(455, 100)
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.chkMostrarFuncionarios)
        Me.GroupBox3.Controls.Add(Me.chkTodosEPI)
        Me.GroupBox3.Controls.Add(Me.cmdEPI)
        Me.GroupBox3.Controls.Add(Me.txtEPI)
        Me.GroupBox3.Controls.Add(Me.lblEPI)
        Me.GroupBox3.Controls.Add(Me.chkTodasEmpresas)
        Me.GroupBox3.Controls.Add(Me.cmdEmpresa)
        Me.GroupBox3.Controls.Add(Me.txtEmpresa)
        Me.GroupBox3.Controls.Add(Me.lblEmpresa)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(448, 91)
        Me.GroupBox3.TabIndex = 86
        Me.GroupBox3.TabStop = False
        '
        'chkTodosEPI
        '
        Me.chkTodosEPI.AutoSize = True
        Me.chkTodosEPI.Checked = True
        Me.chkTodosEPI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosEPI.Location = New System.Drawing.Point(306, 42)
        Me.chkTodosEPI.Name = "chkTodosEPI"
        Me.chkTodosEPI.Size = New System.Drawing.Size(90, 17)
        Me.chkTodosEPI.TabIndex = 74
        Me.chkTodosEPI.Text = "Todos os EPI"
        Me.chkTodosEPI.UseVisualStyleBackColor = True
        '
        'cmdEPI
        '
        Me.cmdEPI.Enabled = False
        Me.cmdEPI.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdEPI.Location = New System.Drawing.Point(278, 39)
        Me.cmdEPI.Name = "cmdEPI"
        Me.cmdEPI.Size = New System.Drawing.Size(22, 23)
        Me.cmdEPI.TabIndex = 73
        Me.cmdEPI.UseVisualStyleBackColor = True
        '
        'txtEPI
        '
        Me.txtEPI.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtEPI.Enabled = False
        Me.txtEPI.Location = New System.Drawing.Point(73, 40)
        Me.txtEPI.Name = "txtEPI"
        Me.txtEPI.ReadOnly = True
        Me.txtEPI.Size = New System.Drawing.Size(203, 20)
        Me.txtEPI.TabIndex = 72
        Me.txtEPI.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEPI
        '
        Me.lblEPI.AutoSize = True
        Me.lblEPI.Location = New System.Drawing.Point(45, 42)
        Me.lblEPI.Name = "lblEPI"
        Me.lblEPI.Size = New System.Drawing.Size(27, 13)
        Me.lblEPI.TabIndex = 71
        Me.lblEPI.Text = "EPI:"
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
        'chkMostrarFuncionarios
        '
        Me.chkMostrarFuncionarios.AutoSize = True
        Me.chkMostrarFuncionarios.Location = New System.Drawing.Point(73, 67)
        Me.chkMostrarFuncionarios.Name = "chkMostrarFuncionarios"
        Me.chkMostrarFuncionarios.Size = New System.Drawing.Size(156, 17)
        Me.chkMostrarFuncionarios.TabIndex = 75
        Me.chkMostrarFuncionarios.Text = "Mostrar funcionários do EPI"
        Me.chkMostrarFuncionarios.UseVisualStyleBackColor = True
        '
        'frmRelEntregaEPIAnalitico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 100)
        Me.Name = "frmRelEntregaEPIAnalitico"
        Me.Text = "Relatório Entrega de EPI Analítico"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodosEPI As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEPI As System.Windows.Forms.Button
    Friend WithEvents txtEPI As DSTextBox.DSTextBox
    Friend WithEvents lblEPI As System.Windows.Forms.Label
    Friend WithEvents chkTodasEmpresas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEmpresa As System.Windows.Forms.Button
    Friend WithEvents txtEmpresa As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents chkMostrarFuncionarios As System.Windows.Forms.CheckBox
End Class
