Public Class frmConfiguracoes

    Private Sub txtMascara_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMascara.KeyPress
        If e.KeyChar <> "." And e.KeyChar <> "9" Then
            e.KeyChar = ""
        End If
    End Sub

End Class