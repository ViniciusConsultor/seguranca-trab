<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelNR
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpData = New System.Windows.Forms.DateTimePicker()
        Me.lblData = New System.Windows.Forms.Label()
        Me.chkTodasEmpresas = New System.Windows.Forms.CheckBox()
        Me.cmdEmpresa = New System.Windows.Forms.Button()
        Me.txtEmpresa = New DSTextBox.DSTextBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.epPadrao = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkTodasNR = New System.Windows.Forms.CheckBox()
        Me.cmdNR = New System.Windows.Forms.Button()
        Me.txtNR = New DSTextBox.DSTextBox()
        Me.lblNR = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(459, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(76, 118)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(3, 90)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Size = New System.Drawing.Size(459, 118)
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.chkTodasNR)
        Me.GroupBox3.Controls.Add(Me.cmdNR)
        Me.GroupBox3.Controls.Add(Me.txtNR)
        Me.GroupBox3.Controls.Add(Me.lblNR)
        Me.GroupBox3.Controls.Add(Me.dtpData)
        Me.GroupBox3.Controls.Add(Me.lblData)
        Me.GroupBox3.Controls.Add(Me.chkTodasEmpresas)
        Me.GroupBox3.Controls.Add(Me.cmdEmpresa)
        Me.GroupBox3.Controls.Add(Me.txtEmpresa)
        Me.GroupBox3.Controls.Add(Me.lblEmpresa)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(448, 103)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        '
        'dtpData
        '
        Me.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpData.Location = New System.Drawing.Point(73, 70)
        Me.dtpData.Name = "dtpData"
        Me.dtpData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpData.Size = New System.Drawing.Size(98, 20)
        Me.dtpData.TabIndex = 72
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(21, 70)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(51, 13)
        Me.lblData.TabIndex = 71
        Me.lblData.Text = "Validade:"
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
        'chkTodasNR
        '
        Me.chkTodasNR.AutoSize = True
        Me.chkTodasNR.Checked = True
        Me.chkTodasNR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodasNR.Location = New System.Drawing.Point(306, 42)
        Me.chkTodasNR.Name = "chkTodasNR"
        Me.chkTodasNR.Size = New System.Drawing.Size(89, 17)
        Me.chkTodasNR.TabIndex = 76
        Me.chkTodasNR.Text = "Todas as NR"
        Me.chkTodasNR.UseVisualStyleBackColor = True
        '
        'cmdNR
        '
        Me.cmdNR.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdNR.Location = New System.Drawing.Point(278, 40)
        Me.cmdNR.Name = "cmdNR"
        Me.cmdNR.Size = New System.Drawing.Size(22, 23)
        Me.cmdNR.TabIndex = 75
        Me.cmdNR.UseVisualStyleBackColor = True
        '
        'txtNR
        '
        Me.txtNR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNR.Location = New System.Drawing.Point(73, 42)
        Me.txtNR.Name = "txtNR"
        Me.txtNR.ReadOnly = True
        Me.txtNR.Size = New System.Drawing.Size(203, 20)
        Me.txtNR.TabIndex = 74
        Me.txtNR.TipoTexto = DSTextBox.DSTextBox.eTipoTexto.Normal
        '
        'lblNR
        '
        Me.lblNR.AutoSize = True
        Me.lblNR.Location = New System.Drawing.Point(44, 44)
        Me.lblNR.Name = "lblNR"
        Me.lblNR.Size = New System.Drawing.Size(26, 13)
        Me.lblNR.TabIndex = 73
        Me.lblNR.Text = "NR:"
        '
        'frmRelNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 118)
        Me.Name = "frmRelNR"
        Me.Text = "Relatório de NR"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodasEmpresas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEmpresa As System.Windows.Forms.Button
    Friend WithEvents txtEmpresa As DSTextBox.DSTextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents epPadrao As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkTodasNR As System.Windows.Forms.CheckBox
    Friend WithEvents cmdNR As System.Windows.Forms.Button
    Friend WithEvents txtNR As DSTextBox.DSTextBox
    Friend WithEvents lblNR As System.Windows.Forms.Label
End Class
