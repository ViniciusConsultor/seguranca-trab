Public Class frmPadraoRelatorio
#Region " Eventos "
    Protected Event imprimir(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Protected Event visualizar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Protected Event sair()
#End Region

#Region " Propriedades/Métodos privados "

    Public Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent imprimir(sender, e)
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        RaiseEvent visualizar(sender, e)
    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

#End Region
End Class