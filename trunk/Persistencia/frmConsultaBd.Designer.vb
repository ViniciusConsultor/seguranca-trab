<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaBd
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.fraGeral = New System.Windows.Forms.GroupBox
        Me.lblTotal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtComando = New System.Windows.Forms.TextBox
        Me.dgvResultado = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fraComando = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.cmdExecutar = New System.Windows.Forms.Button
        Me.fraGeral.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraComando.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGeral
        '
        Me.fraGeral.Controls.Add(Me.lblTotal)
        Me.fraGeral.Controls.Add(Me.Label1)
        Me.fraGeral.Controls.Add(Me.txtComando)
        Me.fraGeral.Controls.Add(Me.dgvResultado)
        Me.fraGeral.Location = New System.Drawing.Point(2, -3)
        Me.fraGeral.Name = "fraGeral"
        Me.fraGeral.Size = New System.Drawing.Size(494, 373)
        Me.fraGeral.TabIndex = 0
        Me.fraGeral.TabStop = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.Color.Navy
        Me.lblTotal.Location = New System.Drawing.Point(423, 354)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(326, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total de Registros:"
        '
        'txtComando
        '
        Me.txtComando.Location = New System.Drawing.Point(6, 12)
        Me.txtComando.Multiline = True
        Me.txtComando.Name = "txtComando"
        Me.txtComando.Size = New System.Drawing.Size(482, 150)
        Me.txtComando.TabIndex = 1
        '
        'dgvResultado
        '
        Me.dgvResultado.AllowUserToAddRows = False
        Me.dgvResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvResultado.BackgroundColor = System.Drawing.Color.White
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResultado.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResultado.Location = New System.Drawing.Point(6, 168)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.RowHeadersVisible = False
        Me.dgvResultado.Size = New System.Drawing.Size(482, 182)
        Me.dgvResultado.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Coluna 1"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 74
        '
        'Column2
        '
        Me.Column2.HeaderText = "Coluna 2"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 74
        '
        'Column3
        '
        Me.Column3.HeaderText = "Coluna 3"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 74
        '
        'Column4
        '
        Me.Column4.HeaderText = "Coluna 4"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 74
        '
        'Column5
        '
        Me.Column5.HeaderText = "Coluna 5"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 74
        '
        'Column6
        '
        Me.Column6.HeaderText = "Coluna 6"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 74
        '
        'fraComando
        '
        Me.fraComando.Controls.Add(Me.cmdSair)
        Me.fraComando.Controls.Add(Me.cmdExecutar)
        Me.fraComando.Location = New System.Drawing.Point(502, -3)
        Me.fraComando.Name = "fraComando"
        Me.fraComando.Size = New System.Drawing.Size(100, 373)
        Me.fraComando.TabIndex = 1
        Me.fraComando.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(7, 344)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(86, 23)
        Me.cmdSair.TabIndex = 1
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'cmdExecutar
        '
        Me.cmdExecutar.Location = New System.Drawing.Point(7, 12)
        Me.cmdExecutar.Name = "cmdExecutar"
        Me.cmdExecutar.Size = New System.Drawing.Size(86, 23)
        Me.cmdExecutar.TabIndex = 0
        Me.cmdExecutar.Text = "Executar"
        Me.cmdExecutar.UseVisualStyleBackColor = True
        '
        'frmConsultaBd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraComando)
        Me.Controls.Add(Me.fraGeral)
        Me.MaximizeBox = False
        Me.Name = "frmConsultaBd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acesso BD"
        Me.fraGeral.ResumeLayout(False)
        Me.fraGeral.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraComando.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGeral As System.Windows.Forms.GroupBox
    Friend WithEvents fraComando As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents cmdExecutar As System.Windows.Forms.Button
    Friend WithEvents txtComando As System.Windows.Forms.TextBox
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
