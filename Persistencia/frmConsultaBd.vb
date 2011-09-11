Imports System.Windows.Forms
Public Class frmConsultaBd
    Private Sub cmdExecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExecutar.Click
        Dim sComando As String
        Dim dtResultado As New DataTable
        Dim iRegistros As Integer
        Dim objAcessoDB As New perAcessoBD

        Try
            dgvResultado.DataSource = Nothing
            dgvResultado.Columns.Clear()
            dgvResultado.AllowUserToAddRows = False
            If (txtComando.Text <> String.Empty) Then
                sComando = txtComando.SelectedText

                If (sComando = String.Empty) Then
                    sComando = txtComando.Text
                End If

                If (InStr(UCase(sComando), "SELECT") = 1) Then
                    dtResultado = objAcessoDB.Executar_Comando(perAcessoBD.eTipoComando.Consulta, sComando)
                    dgvResultado.Rows.Clear()
                    dgvResultado.DataSource = dtResultado
                    lblTotal.Text = dtResultado.Rows.Count
                Else
                    iRegistros = objAcessoDB.Executar_Comando(perAcessoBD.eTipoComando.Acao, sComando)
                    If (iRegistros > 0) Then
                        MsgBox("Comando executado com sucesso.", MsgBoxStyle.Information)
                    End If
                    lblTotal.Text = iRegistros
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub txtComando_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComando.KeyDown
        If (e.KeyCode = Keys.F10) Then
            cmdExecutar_Click(sender, e)
        End If
    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub
End Class