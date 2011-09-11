<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizaRelatorio
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
        Me.crvRelatorio = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvRelatorio
        '
        Me.crvRelatorio.ActiveViewIndex = -1
        Me.crvRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvRelatorio.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvRelatorio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvRelatorio.Location = New System.Drawing.Point(0, 0)
        Me.crvRelatorio.Name = "crvRelatorio"
        Me.crvRelatorio.SelectionFormula = ""
        Me.crvRelatorio.ShowGroupTreeButton = False
        Me.crvRelatorio.ShowRefreshButton = False
        Me.crvRelatorio.Size = New System.Drawing.Size(729, 458)
        Me.crvRelatorio.TabIndex = 0
        Me.crvRelatorio.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvRelatorio.ViewTimeSelectionFormula = ""
        '
        'frmVisualizaRelatorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 458)
        Me.Controls.Add(Me.crvRelatorio)
        Me.Name = "frmVisualizaRelatorio"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvRelatorio As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
