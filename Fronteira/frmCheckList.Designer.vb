<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.fraFiltro = New System.Windows.Forms.GroupBox
        Me.lblStatusCheckList = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.cmdPesquisaCheckList = New System.Windows.Forms.Button
        Me.txtDtInicio = New System.Windows.Forms.DateTimePicker
        Me.lblPeriodo = New System.Windows.Forms.Label
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.cmdPesquisarNR = New System.Windows.Forms.Button
        Me.lblNR = New System.Windows.Forms.Label
        Me.txtNR = New System.Windows.Forms.TextBox
        Me.fraPlanilha = New System.Windows.Forms.GroupBox
        Me.dgvCheckList = New System.Windows.Forms.DataGridView
        Me.fraGeral.SuspendLayout()
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraFiltro.SuspendLayout()
        Me.fraPlanilha.SuspendLayout()
        CType(Me.dgvCheckList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.fraPlanilha)
        Me.fraGeral.Controls.Add(Me.fraFiltro)
        Me.fraGeral.Size = New System.Drawing.Size(885, 574)
        '
        'fraFiltro
        '
        Me.fraFiltro.Controls.Add(Me.lblStatusCheckList)
        Me.fraFiltro.Controls.Add(Me.lblStatus)
        Me.fraFiltro.Controls.Add(Me.cmdPesquisaCheckList)
        Me.fraFiltro.Controls.Add(Me.txtDtInicio)
        Me.fraFiltro.Controls.Add(Me.lblPeriodo)
        Me.fraFiltro.Controls.Add(Me.txtDescricao)
        Me.fraFiltro.Controls.Add(Me.cmdPesquisarNR)
        Me.fraFiltro.Controls.Add(Me.lblNR)
        Me.fraFiltro.Controls.Add(Me.txtNR)
        Me.fraFiltro.Location = New System.Drawing.Point(0, 9)
        Me.fraFiltro.Name = "fraFiltro"
        Me.fraFiltro.Size = New System.Drawing.Size(879, 76)
        Me.fraFiltro.TabIndex = 1
        Me.fraFiltro.TabStop = False
        '
        'lblStatusCheckList
        '
        Me.lblStatusCheckList.BackColor = System.Drawing.Color.White
        Me.lblStatusCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusCheckList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusCheckList.ForeColor = System.Drawing.Color.Navy
        Me.lblStatusCheckList.Location = New System.Drawing.Point(735, 39)
        Me.lblStatusCheckList.Name = "lblStatusCheckList"
        Me.lblStatusCheckList.Size = New System.Drawing.Size(104, 20)
        Me.lblStatusCheckList.TabIndex = 24
        Me.lblStatusCheckList.Text = "Aberto"
        Me.lblStatusCheckList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(689, 43)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 23
        Me.lblStatus.Text = "Status:"
        '
        'cmdPesquisaCheckList
        '
        Me.cmdPesquisaCheckList.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdPesquisaCheckList.Location = New System.Drawing.Point(845, 13)
        Me.cmdPesquisaCheckList.Name = "cmdPesquisaCheckList"
        Me.cmdPesquisaCheckList.Size = New System.Drawing.Size(23, 23)
        Me.cmdPesquisaCheckList.TabIndex = 22
        Me.cmdPesquisaCheckList.UseVisualStyleBackColor = True
        '
        'txtDtInicio
        '
        Me.txtDtInicio.CustomFormat = "MM/yyyy"
        Me.txtDtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDtInicio.Location = New System.Drawing.Point(735, 14)
        Me.txtDtInicio.Name = "txtDtInicio"
        Me.txtDtInicio.Size = New System.Drawing.Size(104, 20)
        Me.txtDtInicio.TabIndex = 21
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(696, 17)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(33, 13)
        Me.lblPeriodo.TabIndex = 20
        Me.lblPeriodo.Text = "Data:"
        '
        'txtDescricao
        '
        Me.txtDescricao.BackColor = System.Drawing.Color.White
        Me.txtDescricao.Location = New System.Drawing.Point(174, 14)
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ReadOnly = True
        Me.txtDescricao.Size = New System.Drawing.Size(510, 49)
        Me.txtDescricao.TabIndex = 15
        '
        'cmdPesquisarNR
        '
        Me.cmdPesquisarNR.Image = Global.Fronteira.My.Resources.Resources.Lupa
        Me.cmdPesquisarNR.Location = New System.Drawing.Point(144, 14)
        Me.cmdPesquisarNR.Name = "cmdPesquisarNR"
        Me.cmdPesquisarNR.Size = New System.Drawing.Size(23, 23)
        Me.cmdPesquisarNR.TabIndex = 14
        Me.cmdPesquisarNR.UseVisualStyleBackColor = True
        '
        'lblNR
        '
        Me.lblNR.AutoSize = True
        Me.lblNR.Location = New System.Drawing.Point(9, 18)
        Me.lblNR.Name = "lblNR"
        Me.lblNR.Size = New System.Drawing.Size(26, 13)
        Me.lblNR.TabIndex = 11
        Me.lblNR.Text = "NR:"
        '
        'txtNR
        '
        Me.txtNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtNR.ForeColor = System.Drawing.Color.Black
        Me.txtNR.Location = New System.Drawing.Point(63, 14)
        Me.txtNR.Name = "txtNR"
        Me.txtNR.ReadOnly = True
        Me.txtNR.Size = New System.Drawing.Size(76, 20)
        Me.txtNR.TabIndex = 10
        '
        'fraPlanilha
        '
        Me.fraPlanilha.Controls.Add(Me.dgvCheckList)
        Me.fraPlanilha.Location = New System.Drawing.Point(0, 79)
        Me.fraPlanilha.Name = "fraPlanilha"
        Me.fraPlanilha.Size = New System.Drawing.Size(879, 491)
        Me.fraPlanilha.TabIndex = 5
        Me.fraPlanilha.TabStop = False
        '
        'dgvCheckList
        '
        Me.dgvCheckList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvCheckList.BackgroundColor = System.Drawing.Color.White
        Me.dgvCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCheckList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCheckList.Location = New System.Drawing.Point(6, 13)
        Me.dgvCheckList.Name = "dgvCheckList"
        Me.dgvCheckList.RowHeadersVisible = False
        Me.dgvCheckList.RowHeadersWidth = 35
        Me.dgvCheckList.RowTemplate.Height = 18
        Me.dgvCheckList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCheckList.Size = New System.Drawing.Size(848, 473)
        Me.dgvCheckList.TabIndex = 5
        '
        'frmCheckList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 574)
        Me.Name = "frmCheckList"
        Me.Text = "Check-List"
        Me.fraGeral.ResumeLayout(False)
        CType(Me.epPadrao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraFiltro.ResumeLayout(False)
        Me.fraFiltro.PerformLayout()
        Me.fraPlanilha.ResumeLayout(False)
        CType(Me.dgvCheckList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents cmdPesquisarNR As System.Windows.Forms.Button
    Friend WithEvents lblNR As System.Windows.Forms.Label
    Friend WithEvents txtNR As System.Windows.Forms.TextBox
    Friend WithEvents fraPlanilha As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCheckList As System.Windows.Forms.DataGridView
    Friend WithEvents lblStatusCheckList As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdPesquisaCheckList As System.Windows.Forms.Button
    Friend WithEvents txtDtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
End Class
