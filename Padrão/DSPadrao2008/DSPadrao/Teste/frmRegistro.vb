Imports DSRegistro
Public Class frmRegistro

    Private obj As New DSRegistro.Registro

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGerarContraChave.Click
        Try
            If String.IsNullOrEmpty(Me.txtChave.Text) Then
                MsgBox("Informe a chave.", MsgBoxStyle.Information, Me.Text)
                Me.txtChave.Focus()
            Else
                Me.txtContraChave.Text = obj.gerarContraChaveRegistro(Me.txtChave.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

End Class