<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditoria
    'Inherits System.Windows.Forms.Form
    Inherits DSFronteiraPadrao.frmPadrao
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdSair = New System.Windows.Forms.Button()
        Me.fraFiltro2 = New System.Windows.Forms.GroupBox()
        Me.txtDataAuditoria = New System.Windows.Forms.DateTimePicker()
        Me.lblDtAuditoria = New System.Windows.Forms.Label()
        Me.fraCheckList = New System.Windows.Forms.GroupBox()
        Me.lblDataCheck = New System.Windows.Forms.Label()
        Me.cmdPesquisaCheckList = New System.Windows.Forms.Button()
        Me.txtDescNR = New System.Windows.Forms.TextBox()
        Me.lblNR = New System.Windows.Forms.Label()
        Me.txtNR = New System.Windows.Forms.TextBox()
        Me.lblStCheckList = New System.Windows.Forms.Label()
        Me.lblAuditoria = New System.Windows.Forms.Label()
        Me.txtIDAuditoria = New System.Windows.Forms.TextBox()
        Me.lblStatusCheckList = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmdPesquisaAuditoria = New System.Windows.Forms.Button()
        Me.dgvAuditoria = New System.Windows.Forms.DataGridView()
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraFiltro2.SuspendLayout()
        Me.fraCheckList.SuspendLayout()
        CType(Me.dgvAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.dgvAuditoria)
        Me.fraGeral.Controls.Add(Me.fraFiltro2)
        Me.fraGeral.Size = New System.Drawing.Size(875, 560)
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(12, 531)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(75, 23)
        Me.cmdSair.TabIndex = 2
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'fraFiltro2
        '
        Me.fraFiltro2.Controls.Add(Me.txtDataAuditoria)
        Me.fraFiltro2.Controls.Add(Me.lblDtAuditoria)
        Me.fraFiltro2.Controls.Add(Me.fraCheckList)
        Me.fraFiltro2.Controls.Add(Me.lblAuditoria)
        Me.fraFiltro2.Controls.Add(Me.txtIDAuditoria)
        Me.fraFiltro2.Controls.Add(Me.lblStatusCheckList)
        Me.fraFiltro2.Controls.Add(Me.lblStatus)
        Me.fraFiltro2.Controls.Add(Me.cmdPesquisaAuditoria)
        Me.fraFiltro2.Location = New System.Drawing.Point(6, 8)
        Me.fraFiltro2.Name = "fraFiltro2"
        Me.fraFiltro2.Size = New System.Drawing.Size(863, 117)
        Me.fraFiltro2.TabIndex = 3
        Me.fraFiltro2.TabStop = False
        '
        'txtDataAuditoria
        '
        Me.txtDataAuditoria.CustomFormat = "MM/yyyy"
        Me.txtDataAuditoria.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataAuditoria.Location = New System.Drawing.Point(195, 13)
        Me.txtDataAuditoria.Name = "txtDataAuditoria"
        Me.txtDataAuditoria.Size = New System.Drawing.Size(93, 20)
        Me.txtDataAuditoria.TabIndex = 25
        '
        'lblDtAuditoria
        '
        Me.lblDtAuditoria.AutoSize = True
        Me.lblDtAuditoria.Location = New System.Drawing.Point(156, 17)
        Me.lblDtAuditoria.Name = "lblDtAuditoria"
        Me.lblDtAuditoria.Size = New System.Drawing.Size(33, 13)
        Me.lblDtAuditoria.TabIndex = 24
        Me.lblDtAuditoria.Text = "Data:"
        '
        'fraCheckList
        '
        Me.fraCheckList.Controls.Add(Me.lblDataCheck)
        Me.fraCheckList.Controls.Add(Me.cmdPesquisaCheckList)
        Me.fraCheckList.Controls.Add(Me.txtDescNR)
        Me.fraCheckList.Controls.Add(Me.lblNR)
        Me.fraCheckList.Controls.Add(Me.txtNR)
        Me.fraCheckList.Controls.Add(Me.lblStCheckList)
        Me.fraCheckList.Location = New System.Drawing.Point(6, 37)
        Me.fraCheckList.Name = "fraCheckList"
        Me.fraCheckList.Size = New System.Drawing.Size(851, 74)
        Me.fraCheckList.TabIndex = 22
        Me.fraCheckList.TabStop = False
        Me.fraCheckList.Text = "Check-List"
        '
        'lblDataCheck
        '
        Me.lblDataCheck.BackColor = System.Drawing.Color.White
        Me.lblDataCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataCheck.Location = New System.Drawing.Point(45, 16)
        Me.lblDataCheck.Name = "lblDataCheck"
        Me.lblDataCheck.Size = New System.Drawing.Size(90, 20)
        Me.lblDataCheck.TabIndex = 26
        Me.lblDataCheck.Text = "__/__/____"
        Me.lblDataCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPesquisaCheckList
        '
        Me.cmdPesquisaCheckList.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdPesquisaCheckList.Location = New System.Drawing.Point(141, 15)
        Me.cmdPesquisaCheckList.Name = "cmdPesquisaCheckList"
        Me.cmdPesquisaCheckList.Size = New System.Drawing.Size(23, 23)
        Me.cmdPesquisaCheckList.TabIndex = 25
        Me.cmdPesquisaCheckList.UseVisualStyleBackColor = True
        '
        'txtDescNR
        '
        Me.txtDescNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescNR.ForeColor = System.Drawing.Color.Black
        Me.txtDescNR.Location = New System.Drawing.Point(259, 17)
        Me.txtDescNR.Multiline = True
        Me.txtDescNR.Name = "txtDescNR"
        Me.txtDescNR.ReadOnly = True
        Me.txtDescNR.Size = New System.Drawing.Size(586, 51)
        Me.txtDescNR.TabIndex = 24
        '
        'lblNR
        '
        Me.lblNR.AutoSize = True
        Me.lblNR.Location = New System.Drawing.Point(170, 21)
        Me.lblNR.Name = "lblNR"
        Me.lblNR.Size = New System.Drawing.Size(26, 13)
        Me.lblNR.TabIndex = 22
        Me.lblNR.Text = "NR:"
        '
        'txtNR
        '
        Me.txtNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtNR.ForeColor = System.Drawing.Color.Black
        Me.txtNR.Location = New System.Drawing.Point(199, 17)
        Me.txtNR.Name = "txtNR"
        Me.txtNR.ReadOnly = True
        Me.txtNR.Size = New System.Drawing.Size(54, 20)
        Me.txtNR.TabIndex = 21
        '
        'lblStCheckList
        '
        Me.lblStCheckList.AutoSize = True
        Me.lblStCheckList.Location = New System.Drawing.Point(6, 20)
        Me.lblStCheckList.Name = "lblStCheckList"
        Me.lblStCheckList.Size = New System.Drawing.Size(33, 13)
        Me.lblStCheckList.TabIndex = 18
        Me.lblStCheckList.Text = "Data:"
        '
        'lblAuditoria
        '
        Me.lblAuditoria.AutoSize = True
        Me.lblAuditoria.Location = New System.Drawing.Point(9, 17)
        Me.lblAuditoria.Name = "lblAuditoria"
        Me.lblAuditoria.Size = New System.Drawing.Size(51, 13)
        Me.lblAuditoria.TabIndex = 21
        Me.lblAuditoria.Text = "Auditoria:"
        '
        'txtIDAuditoria
        '
        Me.txtIDAuditoria.BackColor = System.Drawing.SystemColors.Window
        Me.txtIDAuditoria.ForeColor = System.Drawing.Color.Black
        Me.txtIDAuditoria.Location = New System.Drawing.Point(66, 13)
        Me.txtIDAuditoria.Name = "txtIDAuditoria"
        Me.txtIDAuditoria.ReadOnly = True
        Me.txtIDAuditoria.Size = New System.Drawing.Size(55, 20)
        Me.txtIDAuditoria.TabIndex = 20
        '
        'lblStatusCheckList
        '
        Me.lblStatusCheckList.AutoSize = True
        Me.lblStatusCheckList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusCheckList.Location = New System.Drawing.Point(774, 17)
        Me.lblStatusCheckList.Name = "lblStatusCheckList"
        Me.lblStatusCheckList.Size = New System.Drawing.Size(44, 13)
        Me.lblStatusCheckList.TabIndex = 19
        Me.lblStatusCheckList.Text = "Aberto"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(728, 17)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Status:"
        '
        'cmdPesquisaAuditoria
        '
        Me.cmdPesquisaAuditoria.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdPesquisaAuditoria.Location = New System.Drawing.Point(127, 12)
        Me.cmdPesquisaAuditoria.Name = "cmdPesquisaAuditoria"
        Me.cmdPesquisaAuditoria.Size = New System.Drawing.Size(23, 23)
        Me.cmdPesquisaAuditoria.TabIndex = 16
        Me.cmdPesquisaAuditoria.UseVisualStyleBackColor = True
        '
        'dgvAuditoria
        '
        Me.dgvAuditoria.AllowUserToAddRows = False
        Me.dgvAuditoria.AllowUserToDeleteRows = False
        Me.dgvAuditoria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvAuditoria.BackgroundColor = System.Drawing.Color.White
        Me.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAuditoria.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAuditoria.Location = New System.Drawing.Point(6, 131)
        Me.dgvAuditoria.Name = "dgvAuditoria"
        Me.dgvAuditoria.RowHeadersVisible = False
        Me.dgvAuditoria.RowHeadersWidth = 35
        Me.dgvAuditoria.RowTemplate.Height = 18
        Me.dgvAuditoria.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAuditoria.Size = New System.Drawing.Size(863, 422)
        Me.dgvAuditoria.TabIndex = 7
        '
        'frmAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 560)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAuditoria"
        Me.Text = "Auditoria NR"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraFiltro2.ResumeLayout(False)
        Me.fraFiltro2.PerformLayout()
        Me.fraCheckList.ResumeLayout(False)
        Me.fraCheckList.PerformLayout()
        CType(Me.dgvAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAuditoria As System.Windows.Forms.DataGridView
    Friend WithEvents fraFiltro2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDataAuditoria As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDtAuditoria As System.Windows.Forms.Label
    Friend WithEvents fraCheckList As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPesquisaCheckList As System.Windows.Forms.Button
    Friend WithEvents txtDescNR As System.Windows.Forms.TextBox
    Friend WithEvents lblNR As System.Windows.Forms.Label
    Friend WithEvents txtNR As System.Windows.Forms.TextBox
    Friend WithEvents lblStCheckList As System.Windows.Forms.Label
    Friend WithEvents lblAuditoria As System.Windows.Forms.Label
    Friend WithEvents txtIDAuditoria As System.Windows.Forms.TextBox
    Friend WithEvents lblStatusCheckList As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdPesquisaAuditoria As System.Windows.Forms.Button
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents lblDataCheck As System.Windows.Forms.Label
End Class
