<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelEPIEntregaAnalitico
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
        Me.epRelatorio = New System.Windows.Forms.ErrorProvider(Me.components)
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
        CType(Me.epRelatorio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(456, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(76, 100)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(3, 72)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Size = New System.Drawing.Size(456, 100)
        '
        'epRelatorio
        '
        Me.epRelatorio.ContainerControl = Me
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
        Me.GroupBox3.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(446, 87)
        Me.GroupBox3.TabIndex = 85
        Me.GroupBox3.TabStop = False
        '
        'chkTodosEPI
        '
        Me.chkTodosEPI.AutoSize = True
        Me.chkTodosEPI.Checked = True
        Me.chkTodosEPI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosEPI.Location = New System.Drawing.Point(297, 40)
        Me.chkTodosEPI.Name = "chkTodosEPI"
        Me.chkTodosEPI.Size = New System.Drawing.Size(95, 17)
        Me.chkTodosEPI.TabIndex = 78
        Me.chkTodosEPI.Text = "Todos os tipos"
        Me.chkTodosEPI.UseVisualStyleBackColor = True
        '
        'cmdEPI
        '
        Me.cmdEPI.Enabled = False
        Me.cmdEPI.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdEPI.Location = New System.Drawing.Point(269, 37)
        Me.cmdEPI.Name = "cmdEPI"
        Me.cmdEPI.Size = New System.Drawing.Size(22, 23)
        Me.cmdEPI.TabIndex = 77
        Me.cmdEPI.UseVisualStyleBackColor = True
        '
        'txtEPI
        '
        Me.txtEPI.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtEPI.Enabled = False
        Me.txtEPI.Location = New System.Drawing.Point(64, 38)
        Me.txtEPI.Name = "txtEPI"
        Me.txtEPI.ReadOnly = True
        Me.txtEPI.Size = New System.Drawing.Size(203, 20)
        Me.txtEPI.TabIndex = 76
        Me.txtEPI.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEPI
        '
        Me.lblEPI.AutoSize = True
        Me.lblEPI.Location = New System.Drawing.Point(36, 40)
        Me.lblEPI.Name = "lblEPI"
        Me.lblEPI.Size = New System.Drawing.Size(27, 13)
        Me.lblEPI.TabIndex = 75
        Me.lblEPI.Text = "EPI:"
        '
        'chkTodasEmpresas
        '
        Me.chkTodasEmpresas.AutoSize = True
        Me.chkTodasEmpresas.Checked = True
        Me.chkTodasEmpresas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasEmpresas.Location = New System.Drawing.Point(297, 15)
        Me.chkTodasEmpresas.Name = "chkTodasEmpresas"
        Me.chkTodasEmpresas.Size = New System.Drawing.Size(118, 17)
        Me.chkTodasEmpresas.TabIndex = 74
        Me.chkTodasEmpresas.Text = "Todas as empresas"
        Me.chkTodasEmpresas.UseVisualStyleBackColor = True
        '
        'cmdEmpresa
        '
        Me.cmdEmpresa.Enabled = False
        Me.cmdEmpresa.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdEmpresa.Location = New System.Drawing.Point(269, 13)
        Me.cmdEmpresa.Name = "cmdEmpresa"
        Me.cmdEmpresa.Size = New System.Drawing.Size(22, 23)
        Me.cmdEmpresa.TabIndex = 73
        Me.cmdEmpresa.UseVisualStyleBackColor = True
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Location = New System.Drawing.Point(64, 15)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(203, 20)
        Me.txtEmpresa.TabIndex = 72
        Me.txtEmpresa.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(12, 17)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 71
        Me.lblEmpresa.Text = "Empresa:"
        '
        'chkMostrarFuncionarios
        '
        Me.chkMostrarFuncionarios.AutoSize = True
        Me.chkMostrarFuncionarios.Location = New System.Drawing.Point(64, 64)
        Me.chkMostrarFuncionarios.Name = "chkMostrarFuncionarios"
        Me.chkMostrarFuncionarios.Size = New System.Drawing.Size(124, 17)
        Me.chkMostrarFuncionarios.TabIndex = 89
        Me.chkMostrarFuncionarios.Text = "Mostrar Funcionários"
        Me.chkMostrarFuncionarios.UseVisualStyleBackColor = True
        '
        'frmRelEPIEntregaAnalitico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 100)
        Me.Name = "frmRelEPIEntregaAnalitico"
        Me.Text = "Entrega EPI Analítico"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.epRelatorio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents epRelatorio As System.Windows.Forms.ErrorProvider
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
