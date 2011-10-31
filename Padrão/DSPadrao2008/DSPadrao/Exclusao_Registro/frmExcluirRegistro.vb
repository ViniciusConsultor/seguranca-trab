Public Class frmExcluirRegistro

    Private obj As New DSRegistro.Registro

    Private Sub btnExcluirRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirRegistro.Click
        If MessageBox.Show("Essa ação resultará na exclusão do registro associado ao SegTrab." _
                           & Environment.NewLine & "Confirme a execução dessa exclusão.",
                           Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.obj.excluirRegistro()
            MessageBox.Show("Registro excluído com sucesso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class