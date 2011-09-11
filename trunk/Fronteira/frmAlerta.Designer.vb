<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlerta
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
        Me.tcAlertas = New System.Windows.Forms.TabControl
        Me.tpCheckList = New System.Windows.Forms.TabPage
        Me.dgvCheckList = New System.Windows.Forms.DataGridView
        Me.tpEpi = New System.Windows.Forms.TabPage
        Me.dgvEPI = New System.Windows.Forms.DataGridView
        Me.tpTreinamentos = New System.Windows.Forms.TabPage
        Me.dgvTreinamentos = New System.Windows.Forms.DataGridView
        Me.fraCmd = New System.Windows.Forms.GroupBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.tcAlertas.SuspendLayout()
        Me.tpCheckList.SuspendLayout()
        CType(Me.dgvCheckList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpEpi.SuspendLayout()
        CType(Me.dgvEPI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTreinamentos.SuspendLayout()
        CType(Me.dgvTreinamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCmd.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcAlertas
        '
        Me.tcAlertas.Controls.Add(Me.tpCheckList)
        Me.tcAlertas.Controls.Add(Me.tpEpi)
        Me.tcAlertas.Controls.Add(Me.tpTreinamentos)
        Me.tcAlertas.Location = New System.Drawing.Point(0, 4)
        Me.tcAlertas.Name = "tcAlertas"
        Me.tcAlertas.SelectedIndex = 0
        Me.tcAlertas.Size = New System.Drawing.Size(533, 399)
        Me.tcAlertas.TabIndex = 0
        '
        'tpCheckList
        '
        Me.tpCheckList.Controls.Add(Me.dgvCheckList)
        Me.tpCheckList.Location = New System.Drawing.Point(4, 22)
        Me.tpCheckList.Name = "tpCheckList"
        Me.tpCheckList.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCheckList.Size = New System.Drawing.Size(525, 373)
        Me.tpCheckList.TabIndex = 0
        Me.tpCheckList.Text = "Check-List"
        Me.tpCheckList.UseVisualStyleBackColor = True
        '
        'dgvCheckList
        '
        Me.dgvCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCheckList.Location = New System.Drawing.Point(3, 3)
        Me.dgvCheckList.Name = "dgvCheckList"
        Me.dgvCheckList.Size = New System.Drawing.Size(519, 367)
        Me.dgvCheckList.TabIndex = 0
        '
        'tpEpi
        '
        Me.tpEpi.Controls.Add(Me.dgvEPI)
        Me.tpEpi.Location = New System.Drawing.Point(4, 22)
        Me.tpEpi.Name = "tpEpi"
        Me.tpEpi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEpi.Size = New System.Drawing.Size(525, 373)
        Me.tpEpi.TabIndex = 1
        Me.tpEpi.Text = "EPI"
        Me.tpEpi.UseVisualStyleBackColor = True
        '
        'dgvEPI
        '
        Me.dgvEPI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvEPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEPI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEPI.Location = New System.Drawing.Point(3, 3)
        Me.dgvEPI.Name = "dgvEPI"
        Me.dgvEPI.Size = New System.Drawing.Size(519, 367)
        Me.dgvEPI.TabIndex = 1
        '
        'tpTreinamentos
        '
        Me.tpTreinamentos.Controls.Add(Me.dgvTreinamentos)
        Me.tpTreinamentos.Location = New System.Drawing.Point(4, 22)
        Me.tpTreinamentos.Name = "tpTreinamentos"
        Me.tpTreinamentos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTreinamentos.Size = New System.Drawing.Size(525, 373)
        Me.tpTreinamentos.TabIndex = 2
        Me.tpTreinamentos.Text = "Treinamentos"
        Me.tpTreinamentos.UseVisualStyleBackColor = True
        '
        'dgvTreinamentos
        '
        Me.dgvTreinamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTreinamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTreinamentos.Location = New System.Drawing.Point(3, 3)
        Me.dgvTreinamentos.Name = "dgvTreinamentos"
        Me.dgvTreinamentos.Size = New System.Drawing.Size(519, 367)
        Me.dgvTreinamentos.TabIndex = 1
        '
        'fraCmd
        '
        Me.fraCmd.Controls.Add(Me.cmdSair)
        Me.fraCmd.Location = New System.Drawing.Point(539, -2)
        Me.fraCmd.Name = "fraCmd"
        Me.fraCmd.Size = New System.Drawing.Size(92, 408)
        Me.fraCmd.TabIndex = 1
        Me.fraCmd.TabStop = False
        '
        'cmdSair
        '
        Me.cmdSair.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSair.Location = New System.Drawing.Point(3, 379)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(86, 26)
        Me.cmdSair.TabIndex = 2
        Me.cmdSair.Text = "Sair"
        Me.cmdSair.UseVisualStyleBackColor = True
        '
        'frmAlerta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 405)
        Me.Controls.Add(Me.fraCmd)
        Me.Controls.Add(Me.tcAlertas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlerta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alertas"
        Me.tcAlertas.ResumeLayout(False)
        Me.tpCheckList.ResumeLayout(False)
        CType(Me.dgvCheckList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpEpi.ResumeLayout(False)
        CType(Me.dgvEPI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTreinamentos.ResumeLayout(False)
        CType(Me.dgvTreinamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCmd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcAlertas As System.Windows.Forms.TabControl
    Friend WithEvents tpCheckList As System.Windows.Forms.TabPage
    Friend WithEvents tpEpi As System.Windows.Forms.TabPage
    Friend WithEvents fraCmd As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    Friend WithEvents tpTreinamentos As System.Windows.Forms.TabPage
    Friend WithEvents dgvCheckList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEPI As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTreinamentos As System.Windows.Forms.DataGridView
End Class
